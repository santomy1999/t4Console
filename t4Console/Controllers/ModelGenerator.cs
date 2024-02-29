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
    public class ModelGenerator
    {
        private readonly FieldRepo _fieldRepo;
        private readonly DomainModelGenerator _domainGen;
        public ModelGenerator(CGDBContext cgdbContext)
        {
            _fieldRepo = new FieldRepo(cgdbContext);
            _domainGen = new DomainModelGenerator(cgdbContext);
        }
        public async Task  GenerateModel(Page page)
        {
            var fields = await _fieldRepo.getFields(page.PageId);

            var domainFields = fields.Where(f => f.FieldType == "select").ToList();
            if(domainFields.Any())
            {
				Console.WriteLine("Generating domain models...");

				await _domainGen.GenerateDomainModels(domainFields);
			}
           
            
            var model = new ModelTemplate()
            {
                ProjectName = ProjectData.ProjectName,
                page = page,
                Name = page.PageTitle,
                fields = fields 
            };
            var modelString = model.TransformText();
            /*string dirName = ProjectData.ProjectLocation+ "\\"+ProjectData.ProjectName + "\\Models\\";*/
            string dirName = ProjectData.getModelSaveLocation();
            string fileName = dirName + page.PageIdentifier + "Model.cs";

            File.WriteAllText(fileName, modelString);
        }
    }
}
