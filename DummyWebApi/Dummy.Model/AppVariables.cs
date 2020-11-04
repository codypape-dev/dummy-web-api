using Microsoft.Extensions.Configuration;

namespace Dummy.Model
{
    public static class AppVariables
    {
        public static string DBConnection { get; set; }
        public static string DatabaseName { get; set; }
        public static string DocumentationXML { get; set; }
        public static string EnableTrace { get; set; }
        public static void SetEnviroment(IConfiguration Configuration)
        {
            DBConnection = Configuration["DBConnection"];
            EnableTrace = Configuration["EnableTrace"];
            DocumentationXML = Configuration["Swagger:FileName"].ToString();
            DatabaseName = Configuration["DatabaseName"];
        }

    }
}
