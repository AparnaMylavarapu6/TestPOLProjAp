using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentersInsuranceApiTests.Controllers
{
    internal static class PropertiesController
    {
        /* This method figures out the path to properties.ini file */
        public static string getPropertiesPath()
        {
            //If environment variable is set for PROPERTIES_FILE_PATH, then use that. 
            //Otherwise, default to Application directory. 
            var path = Environment.GetEnvironmentVariable("PROPERTIES_FILE_PATH");
            if (path == null || path.Length == 0)
                path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\Debug\\" + "properties.ini";
            return path;
        }

        /* This method loads the content of properties.ini file to a Dictionary, dumps output to console 
         * INPUT    : string directory and file path to the properties file (e.g., properties.ini)
         * OUTPUT   : Dictionary<string, string> set of properties 
         */
        public static Dictionary<string, string> readProperties(string propsPath)
        {
            var data = new Dictionary<string, string>();
            try
            {
                foreach (var row in File.ReadAllLines(propsPath))
                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                data = null;
            }

            return data;
        }
    }
}