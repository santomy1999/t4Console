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
	public class DomainModelGenerator
	{
		private readonly FieldRepo _fieldRepo;
		public DomainModelGenerator(CGDBContext cgdbContext)
        {
			_fieldRepo = new FieldRepo(cgdbContext);
		}
        public async Task GenerateDropDownModel(Field field)
        {
            var domainList = await _fieldRepo.GetFieldDomains(field.FieldId);
            var domainModel = new DomainModelsTemplate()
            {
                ProjectName = ProjectData.ProjectName,
                field = field,
                domainData = domainList
            };
			var domainModelrString = domainModel.TransformText();
			string dirName = ProjectData.getDomainModelSaveLocation();

			string fileName = dirName + "\\" +field.FieldName + "Domains.cs";

			File.WriteAllText(fileName, domainModelrString);
		}
        public async Task GenerateDomainModels(List<Field> fields)
        {
            var domainLoc = ProjectData.getDomainModelSaveLocation();

			if (!Directory.Exists(domainLoc))
            {
                var res = Directory.CreateDirectory(domainLoc);
            }
			

			foreach (var field in fields)
            {
               await GenerateDropDownModel(field);
			}

        }
    }
}
