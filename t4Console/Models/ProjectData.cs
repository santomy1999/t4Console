using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t4Console.Models
{
    public class ProjectData
    {
        public static string ProjectName = "";
        public static string ProjectLocation = "";
        public static string getSaveLocation()
        {
            return ProjectLocation+ "\\" + ProjectName + "\\" + ProjectName;  
        }
        public static string getLayoutSaveLocation()
        {
            return (getSaveLocation() + "\\Views\\" + "Shared\\");
        }
        public static string getModelSaveLocation()
        {
            return (getSaveLocation() + "\\Models\\");
        }
        public static string getControllerSaveLocation()
        {
            return (getSaveLocation() + "\\Controllers\\");
        }
        public static string getViewSaveLocation(string viewName)
        {
            return (getSaveLocation()  + "\\Views\\" + viewName);
        }
        public static string getDomainModelSaveLocation()
        {
			return getSaveLocation() + "\\Models\\" + "DomainValues";
		}
    }
}
