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
            return ProjectLocation+ "\\" + ProjectName;  
        }
        public static string getLayoutSaveLocation()
        {
            return ProjectLocation + "\\" + ProjectName + "\\Views\\" + "Shared\\";
        }
        public static string getModelSaveLocation()
        {
            return ProjectLocation + "\\" + ProjectName  + "\\Models\\";
        }
        public static string getControllerSaveLocation()
        {
            return ProjectLocation + "\\" + ProjectName  + "\\Controllers\\";
        }
        public static string getViewSaveLocation(string viewName)
        {
            return ProjectLocation + "\\" + ProjectName  + "\\Views\\" + viewName;
        }
        public static string getDomainModelSaveLocation()
        {
			return ProjectLocation + "\\" + ProjectName + "\\Models\\" + "DomainValues";
		}
    }
}
