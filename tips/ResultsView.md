## Watch Window Results View 
When looking at collections in the watch window you can add a *format specifier* of `, results` to just look at all the items in a collection.

1. Navigate to the **Recipe.Service** project and in **Models/RecipeManager.cs**, set a breakpoint on **line 69** in the `GetRecipes()` function. 

![Breakpoint set on RecipeManager.cs line 69](ResultsView-SetBreakpoint1.png)

2. Launch the application and hit the breakpoint.
3. Add a watch value of `recipes`.

![Watch view of 'recipes'](ResultsView-NoResultsWatch.png)

4. Add a watch value of `recipes, results` and note how the items in the `IEnumerable` are children of the watch and no other properties are shown.

![Watch view of 'recipes, results'](ResultsView-Watch.png)


As you can see with the `, results` format specifier, the items in a collection are shown as children making it easier to view the items in a collection.