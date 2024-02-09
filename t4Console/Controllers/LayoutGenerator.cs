using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t4Console.Models;
using t4Console.Templates;

namespace t4Console.Controllers
{
    public class LayoutGenerator
    {
        public LayoutGenerator()
        {
            
        }
        public void GenerateLayout(List<Page> pages)
        {

            
            var layout = new _LayoutTemplate()
            {
                ProjectName = ProjectData.ProjectName,
                pages = pages
            };

            var LayoutString = layout.TransformText();
            string dirName = ProjectData.getLayoutSaveLocation();

            string fileName = dirName + "\\" + "_Layout.cshtml";
            File.WriteAllText(fileName, LayoutString);
        }
    }
}
