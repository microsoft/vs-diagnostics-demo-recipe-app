# Snapshots on Exceptions
The *Snapshots on Exceptions* feature of IntelliTrace takes snapshots of your application when an exception occurs. You can then use the *Diagnostic Tools* window to inspect that exception and *all* the state of your application when the exception occured.

## Prerequsites
1. To enable Snapshots on Exceptions follow the steps to [Enable Snapshots](EnableSnapshots.md).
2. Enable debugging only for `Recipe.PublicWebMVC`  using the [Multiple Startup Projects Dialog](MultipleStartupProjects.md).

## Example - Exceptions


1. Stat debugging `F5`.
2. Navigate the browser to `http://localhost:61906/`.
3. Choose a recipe and click on it to navigate to it's details page (e.g. `http://localhost:61906/home/recipe/715702`). You should get an error page but not stop in the debugger.
4. Go to Visual Studio and open the `Diagnostic Tools` window (it should already be open on the right hand side).
5. Go to the *Events* tab. 
6. In the `Filter Events` box type *exception* to filter the list down to just the exceptions.
7. Select the *Exception* event with the *snapshot* icon (![Snapshot icon](SnapshotOnException-SnapshotIcon.png)), this indicates that a snapshot was taken for this exception.

![Diagnostic tool window](SnapshotOnException-DiagnosticToolWindow.png)

8. *Double click* on the event or click on *Activate Historical Debugging* link.
9. Visual Studio is now debugging the exception that caused the `View` to faile to render!  

## Example - Async Exceptions
The snapshot feature is really powerfull when debugging code that is using `await` or other async patterns. One of the challens with async code is that an exception that has occured previoussly might be responsible for an exception that you are currently debugging. As the code is async the app being debugged has moved on and none of the state from that previous point in time exsists - so you can't inspect. This is where snapshots on exceptions really comes into it's own.

1. Follow the steps in the example above.
2. Looking at the exception it's not tell us anything usefull. Clearly `recipe` is `null` but the question is why, something earlier returned null and as it was an `async` `Task` that can't be inspected from this location.

![Code for final exception](SnapshotOnException-CodeForFinalException.png)

3. In the `Diagnostic Tools` window activate the first, oldest, exception (there should be 3) and look at the code. As you can see this the source of the problem, the hostname for the API endpoint is wrong.

![Code for first exception](SnapshotOnException-CodeForFirstException.png)



## Example = Async Exceptions (Simplified)

1. Set the project `AsyncExceptionConsoleDemo` as the *only* startup project.

![Seting startup project](SnapshotOnException-SetStartupProject.png)

2. Press *F5*/*Start Debugging*
3. Visual Studio will stop on the exception on line `25`.
![Stopped in ](SnapshotOnException-ConsoleFinalException.png)

4. In the `Diagnostic Tools` window select the first exception.

![Diagnostic Tools window with exceptions](SnapshotOnException-ConsoleDiagToolsWindow.png)

5. *Double click* on the event or click on *Activate Historical Debugging* link.
6. Inspect `p` and note it's `null`. This is the source of the problem and where a null check is needed to fix the 'bug'.

![Stopped on exception](SnapshotOnException-ConsoleFirstException.png)

