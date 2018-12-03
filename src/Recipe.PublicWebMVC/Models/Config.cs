using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicWebMVC.Models
{
    public class Config
    {
        public static Config Singleton;

        public Uri RestApiUri
        {
            get;
            private set;
        }

        public string WwwRootFolder
        {
            get;
            private set;
        }

        public DiagHubTrace HubTrace
        {
            get;
            private set;
        }

        public Config(IHostingEnvironment env)
        { 
            if(env.IsDevelopment())
            {
                RestApiUri = new Uri("http://localhost:64407");
            }
            else
            {
                RestApiUri = new Uri("http://andster-build2018-recipe-api.azurewebsites.net");
            }

            WwwRootFolder = env.WebRootPath;

            DefineUserMarks();
        }

        private void DefineUserMarks()
        {
            HubTrace = new DiagHubTrace();

            HubTrace.DefineIdName((ushort)UserMarks.RecipeLoadStart, nameof(UserMarks.RecipeLoadStart));
            HubTrace.DefineIdName((ushort)UserMarks.RecipeLoadEnd, nameof(UserMarks.RecipeLoadEnd));
        }


    }

    public enum UserMarks:ushort
    {
        RecipeLoadStart = 2,
        RecipeLoadEnd = 3
    }
}
