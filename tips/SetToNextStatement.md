# Set To Next Statement
While Run to Cursor and Run to Click will execute your application up to where you choose to break, **Set to Next Statement** allows you jump around your code without executing any code in-between.

1.	In the **Recipe.Service** project, navigate to the **GetRecipesByName()** function in **Models/RecipeManager.cs** file.

2.	Set a breakpoint at **line 49** and run the application.

3.	In the recipe application’s search box, enter **“butter”**. Execute the search.

4.	In Visual Studio, right click on **line 58** and select the **“Run to Click”** glyph to run execution up to **line 58**, the end of the first loop iteration.  You can check that the recipes array contains only 1 item.

5.	Drag the yellow arrow on the left of **line 58** to **line 60**. Hover over the recipes array to observe that it still contains only 1 item.  You can also perform the same task by right-clicking and selecting **“Set to Next Statement”** in the context menu or by using the keyboard shortcut **Ctrl+Shift+F10** after putting your cursor on the desired line.

![Drag set to next statement arrow to new line](SetToNextStatement-DragArrow.png)

6.	Hit **Continue** on the Debug toolbar to view the application’s search results.  Unlike the results of the Run to Click and Run to Cursor sections which displayed 3 search results containing the “butter” substring, this search will only display the first result because we skipped the rest of the `for` loop’s execution.

![Search results after set to next statement](SetToNextStatement-SearchResult.png)

**Set to Next Statement** is a good feature to use when you want to skip over buggy code while debugging or when you want to re-execute code after an edit has been made.