# Number Formatting
In the watch window you can force the visualization of an int into either it's decimal or hexadecimal representation with the respective `,d` and `,h` format specifiers. This is esepecially usefull for looking at values derrived from HRESULTS.


1. Set a breakpoint on `RecipeManager.cs` line `55` in the `GetRecipes`. 

![Breakpoint set on RecipeManager.cs line 55](NumberFormatting-SetBreakpoint.png)

2. Launch the project and hit the breakpoint.
3. Add a watch value of `limit`.
4. Add a watch value of `limit, h` to see the hexadecimal representation of `limit`.

![Watch window with watches for 'limit' and 'limit, h'](NumberFormatting-Watch.png)

## Context Menu
You can also accomplish the same thing with the *Hexidecimal Display* context menu item for a watch.

![Context menu for watch window with 'Hexidecimal Display' selected](NumberFormatting-ContextMenu.png) 
