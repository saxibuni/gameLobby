using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace mainProgram
{
    public class PackageClass
    {
        public string name = "";
        public string main = "";
        public string description = "";
        public string author = "";
        public string license = "";
        public string merchantCode = "";
        public string language = "";
        public string lan = "";
        public string updateUrl = "";

        public string release = "";
    }


    public class JsonHelper
    {
        public static string getJsonText()
        {
            string contents = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "resources\\app\\package.json");
            return contents;
        }

        public static dynamic getPackage()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var jsonStr = getJsonText();
            dynamic model = js.Deserialize<dynamic>(jsonStr);
            return model;
            
        }
    }
}
