// -----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------------

namespace PublicWebMVC.Models
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public sealed class DiagHubTrace : IDisposable
    {
        public static readonly Guid DiagHubProviderId = new Guid("F9189F8A-0753-4A70-AD66-D622D88DB986");
        public static readonly ushort FirstValidId = 1;
        public static readonly ushort MaxValidId = 0x7fff;

        private const int SuccessErrorCode = 0;

        // The max size limit of an ETW payload is 64k, but that includes the header.
        // We take off a bit for ourselves.
        private const int MaxMsgSizeInBytes = 63 * 1024;

        private long regHandle;
        private bool started = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagHubTrace"/> class.
        /// </summary>
        public DiagHubTrace()
        {
            this.Initialize();
        }

        /// <summary>
        /// Insert mapping from ID to name
        /// </summary>
        /// <param name="id">ID to name</param>
        /// <param name="name">Name of ID</param>
        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        public void DefineIdName(ushort id, string name)
        {
            if (this.started)
            {
                Debug.Assert(id <= MaxValidId, "Invalid ID");
                this.FireUserEventIdNameMap(id, name);
            }
        }

        /// <summary>
        /// Insert mark into the collection stream
        /// </summary>
        /// <param name="id">ID of mark</param>
        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        public void InsertMark(ushort id)
        {
            if (this.started)
            {
                Debug.Assert(FirstValidId <= id && id <= MaxValidId, "Invalid ID");
                this.FireUserEventWithString(id, null);
            }
        }

        /// <summary>
        /// Insert mark with message into the collection stream
        /// </summary>
        /// <param name="id">ID of mark</param>
        /// <param name="message">Message of mark</param>
        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        public void InsertMarkWithMessage(ushort id, string message)
        {
            if (this.started)
            {
                Debug.Assert(FirstValidId <= id && id <= MaxValidId, "Invalid ID");
                this.FireUserEventWithString(id, message);
            }
        }

        /// <summary>
        /// Insert message into the collection stream
        /// </summary>
        /// <param name="message">Message to insert</param>
        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        public void InsertMessage(string message)
        {
            if (this.started)
            {
                this.FireUserEventWithString(0, message);
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Shutdown();
        }

        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        private void Initialize()
        {
            Guid localId = DiagHubTrace.DiagHubProviderId;
            if (DiagHubTrace.SuccessErrorCode == NativeMethods.EventRegister(ref localId, IntPtr.Zero, IntPtr.Zero, ref this.regHandle))
            {
                this.started = true;
            }
        }

        [Conditional("DIAGHUB_ENABLE_TRACE_SYSTEM")]
        private void Shutdown()
        {
            if (this.started)
            {
                this.started = false;
                NativeMethods.EventUnregister(this.regHandle);
            }
        }

        private void FireUserEventIdNameMap(ushort id, string name)
        {
            Debug.Assert(id <= MaxValidId, "Invalid ID");
            Debug.Assert(name != null && (2 * name.Length) < MaxMsgSizeInBytes, "Invalid string argument");

            NativeMethods.EVENT_DESCRIPTOR evtDesc = new NativeMethods.EVENT_DESCRIPTOR()
            {
                Id = 0xffff,
                Version = 1,
                Channel = 0,
                Level = 4, // TRACE_LEVEL_INFORMATION
                Opcode = 0,
                Task = 0,
                Keyword = 1
            };

            GCHandle idPinned = GCHandle.Alloc(id, GCHandleType.Pinned);

            int nameLenInBytes = 2 * (name.Length + 1);
            GCHandle namePinned = GCHandle.Alloc(name, GCHandleType.Pinned);

            NativeMethods.EVENT_DATA_DESCRIPTOR[] userData = new NativeMethods.EVENT_DATA_DESCRIPTOR[2];
            userData[0].DataPointer = idPinned.AddrOfPinnedObject().ToInt64();
            userData[0].Size = sizeof(ushort);
            userData[1].DataPointer = namePinned.AddrOfPinnedObject().ToInt64();
            userData[1].Size = nameLenInBytes;

            GCHandle userDataPinned = GCHandle.Alloc(userData, GCHandleType.Pinned);
            NativeMethods.EventWrite(this.regHandle, ref evtDesc, userData.Length, userDataPinned.AddrOfPinnedObject());

            userDataPinned.Free();
            namePinned.Free();
            idPinned.Free();
        }

        private void FireUserEventWithString(ushort id, string message)
        {
            Debug.Assert(id <= MaxValidId, "Invalid ID");
            NativeMethods.EVENT_DESCRIPTOR evtDesc = new NativeMethods.EVENT_DESCRIPTOR()
            {
                Id = id,
                Version = 1,
                Channel = 0,
                Level = 4, // TRACE_LEVEL_INFORMATION
                Opcode = 0,
                Task = 0,
                Keyword = 1
            };

            int nameLenInBytes = message == null ? 0 : (2 * (message.Length + 1));
            Debug.Assert(nameLenInBytes < MaxMsgSizeInBytes, "Invalid DiagHub mark");
            GCHandle msgPinned = GCHandle.Alloc(message, GCHandleType.Pinned);

            NativeMethods.EVENT_DATA_DESCRIPTOR userData = new NativeMethods.EVENT_DATA_DESCRIPTOR()
            {
                DataPointer = msgPinned.AddrOfPinnedObject().ToInt64(),
                Size = nameLenInBytes,
            };

            GCHandle userDataPinned = GCHandle.Alloc(userData, GCHandleType.Pinned);
            NativeMethods.EventWrite(this.regHandle, ref evtDesc, 1, userDataPinned.AddrOfPinnedObject());

            userDataPinned.Free();
            msgPinned.Free();
        }

        private sealed class NativeMethods
        {
            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern int EventRegister(
                ref Guid guid,
                [Optional] IntPtr enableCallback,
                [Optional] IntPtr callbackContext,
                [In][Out] ref long regHandle);

            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern int EventWrite(
                [In] long regHandle,
                [In] ref EVENT_DESCRIPTOR evtDesc,
                [In] int userDataCount,
                [In] IntPtr userData);

            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern int EventUnregister([In] long regHandle);

            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct EVENT_DESCRIPTOR
            {
                [FieldOffset(0)] public ushort Id;
                [FieldOffset(2)] public byte Version;
                [FieldOffset(3)] public byte Channel;
                [FieldOffset(4)] public byte Level;
                [FieldOffset(5)] public byte Opcode;
                [FieldOffset(6)] public ushort Task;
                [FieldOffset(8)] public ulong Keyword;
            }

            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct EVENT_DATA_DESCRIPTOR
            {
                [FieldOffset(0)] public Int64 DataPointer;
                [FieldOffset(8)] public int Size;
                [FieldOffset(12)] public int Reserved;
            }
        }
    }
}
