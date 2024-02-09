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
    public class ViewGenerator
    {
        private readonly FieldRepo _fieldRepo;
        public ViewGenerator(CGDBContext cgdbContext) 
        {
            _fieldRepo = new FieldRepo(cgdbContext);
        }
        public async Task GenerateView(Page page)
        {
            var fields = await _fieldRepo.getFields(page.PageId);
            var domainValues = await _fieldRepo.GetPageDomains(page.PageId);
            var view = new ViewTemplate()
            {
                ProjectName = ProjectData.ProjectName,
                page = page,
                Name = page.PageTitle,
                fields= fields,
                domainValues = domainValues
            };
            var controllerString = view.TransformText();
            string dirName = ProjectData.getViewSaveLocation(page.PageIdentifier);

            if(!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            string fileName = dirName + "\\"+"Index.cshtml";

            File.WriteAllText(fileName, controllerString);
        }
    }
}
