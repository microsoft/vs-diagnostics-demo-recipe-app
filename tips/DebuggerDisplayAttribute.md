# Debugger Display Attribute
When inspecting objects in the debugger, a default representation of the object is shown. Typically for classes, it's just the class name which often isn't that useful. Instead you can control what the debugger shows by providing a `[DebuggerDisplay()]` attribute on the class definition. 


## Example - No [DebuggerDisplay()]
1. Navigate to the **Recipe.Service** project and in **Models/RecipeManager.cs**, set a breakpoint on **line 69** in the `GetRecipes()` function. 

![Breakpoint set on RecipeManager.cs line 69](ResultsView-SetBreakpoint2.png)

2. Launch the application and hit the breakpoint.
3. Hover over the `recipes` object and expand the `ResultsView` note how each recipe just has their class name, which is not very useful.

![DataTip expanded with the default visualizer](DebuggerDisplayAttribute-DefaultViewInDataTip.png)

4. Stop debugging.

## Example - With [DebuggerDisplay()]
Now let's add a `[DebuggerDisplay()]` attribute on the `Recipe` class to improve that visualization.

1. Open **Models\Recipe.cs** in **Recipe.Service** project.
2. Add a `using` statement for `System.Diagnostics` at the top of the file.

`using System.Diagnostics;` 

3. Above the class declaration for `Recipe` on **line 11** add:

`[DebuggerDisplay("{Title,nq}")]`
 
![DebuggerDisplay attribute](DebuggerDisplayAttribute-AttributeAdded.png)

_Bonus Tip_: The format specifier `,nq` 'no quotes' will cause strings to be displayed without quotation marks at the start and end of the string.

4. Launch the application and hit the breakpoint previously set on **RecipeManager.cs** on **line 68** in the `GetRecipes()` function.
5. Hover over the `recipes` object and expand the `ResultsView`. Note how each recipe now shows the title, which is much more useful and readable!

![DataTip expanded with the custom visualizer](DebuggerDisplayAttribute-CustomViewInDataTip.png)


## Example - Expressions in Display Attributes
The `[DebuggerDisplay()]` attribute uses the same string formatting as **TracePoints** and other VS features allowing you to display more complex strings.

1. Back in **Models\Recipe.cs line 11** modify the `[DebuggerDisplayAttribute]` to:

`[DebuggerDisplay("{Title,nq}, id: {Id}")]`

![DebuggerDisplay attribute](DebuggerDisplayAttribute-ComplexAttributeAdded.png)

2. Launch the application and hit the breakpoint previously set on **RecipeManager.cs line 68** in the `GetRecipes()` function.
3. Hover over the `recipes` object and expand the `ResultsView`. Note how each recipe now each shows the title and id.

![DataTip expanded with the custom visualizer](DebuggerDisplayAttribute-CustomExpressionViewInDataTip.png)


## Further Documentation
For more information on `DebuggerDisplay`, take a look at the [documentation](https://docs.microsoft.com/en-us/visualstudio/debugger/using-the-debuggerdisplay-attribute) on docs.microsoft.com.

