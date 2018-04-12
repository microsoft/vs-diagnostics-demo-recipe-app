# Watch Window Results View 
When looking at collections in the watch window you can add a *format specifier* of `, results` to just look at all the items in a collection.

1. Set a breakpoint on `RecipeManager.cs` line `55` in the `GetRecipes`. 

![Breakpoint set on RecipeManager.cs line 55](ResultsView-SetBreakpoint.png)

2. Launch the project and hit the breakpoint.
3. Add a watch value of `recipes`.

![Watch view of 'recipes'](ResultsView-NoResultsWatch.png)

4. Add a watch value of `recipes, results` and note how the items in the `IEnumebrable` are children of the watch and no other properties are shown.

![Watch view of 'recipes, results'](ResultsView-Watch.png)


As you can see with the `, results` format specifer the items in a collection are shown as a children making it easier to get to look at the items in a collection.