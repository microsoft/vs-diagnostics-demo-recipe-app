# Callstack Parameter Values
The callstack window can be customized to show a vareity of different properties on each frame in the stack. One of the most usefull is showing the values that were past into each function. This gives you a quick view of the inputs passed into each function.

## Example - Just Values
1. Set a breakpoint on `RecipeManager.cs` line `55` in the `GetRecipes`. 

![Breakpoint set on RecipeManager.cs line 55](CallstackParameterValues-SetBreakpoint.png)

2. Launch the project and hit the breakpoint.
3. Open the *Callstack* window's *Context menu* (Right click on a call frame)

![Callstack window context menu](CallstackParameterValues-CallstackContextMenu.png)

4. Select *Show Parameter Values* 

![Callstack window with ](CallstackParameterValues-CallstackWindow.png)

## Notes
There's a bunch of options to configure how to customize the look of the callstack window to suit you. Have a play with them and figure out what works for you! 