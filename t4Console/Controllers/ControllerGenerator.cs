using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t4Console.Models;
using t4Console.Repository;
using t4Console.Templates;

namespace t4Console.Controllers
{
    public class ControllerGenerator
    {
        private readonly FieldRepo _fieldRepo;
        public ControllerGenerator(CGDBContext cgdbContext) {
            _fieldRepo = new FieldRepo(cgdbContext);
        }
        public async Task GenerateController(Page page)
        {
            var fields =await _fieldRepo.getFields(page.PageId);
            var controller = new ControllerTemplate()
            {
                ProjectName = ProjectData.ProjectName,
                page = page,
                fields = fields

            };
            var controllerString = controller.TransformText();
            string dirName = ProjectData.getControllerSaveLocation();

            string fileName = dirName + page.PageIdentifier + "Controller.cs";

            File.WriteAllText(fileName, controllerString);
        }
    }
}
