# Multiple Startup Projects
If you have a solution with multiple projects, Visual Studio can launch any number of those projects when you press **F5** in the IDE.  The recipe application consists of a .NET Web API project and a .NET Core MVC project. Each of these projects need to be running simultaneously, so we need to establish multiple startup projects.

1. In **Solution Explorer** find the solution root node.

![Solution Explorer with solution node selected](MultipleStartupProjects-SolutionNode.png)

2. **Right Click -> Properties** - It's the last item on the context menu. You can also do **Right Click -> Set Startup Project..** to accomplish the same task.

![Solution Explorer context menu with the properties item selected](MultipleStartupProjects-SolutionProperties.png)

3. In the dialog that appears choose **Multiple startup projects**.

![Solution properties dialog](MultipleStartupProjects-SolutionPropertiesDialog1.png)

4. Set `Recipe.PublicWebMVC` and `Recipe.Service` to **Start**.

5. Now press *F5* and you should see two browsers launches at the startup page for each project.