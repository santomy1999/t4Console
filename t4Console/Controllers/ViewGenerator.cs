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
        public async Task GenerateView(Page page,Page? Previous, Page? Next)
        {
            ProjectData.ProjectName.ToLowerInvariant();
            var fields = await _fieldRepo.getFields(page.PageId);
            var domainValues = await _fieldRepo.GetPageDomains(page.PageId);
            var indexView = new View_Index_Template()
            {
                ProjectName = ProjectData.ProjectName,
                page = page,
                Name = page.PageTitle,
                fields= fields,
                domainValues = domainValues,
                NextPage = Next,
                PreviousPage = Previous
            };
			var detailsView = new View_Details_Template()
			{
				ProjectName = ProjectData.ProjectName,
				page = page,
				Name = page.PageTitle,
				fields = fields,
				domainValues = domainValues,
				NextPage = Next,
				PreviousPage = Previous
			};
			var indexViewString = indexView.TransformText();
			var detailsViewString = detailsView.TransformText();
			string dirName = ProjectData.getViewSaveLocation(page.PageIdentifier);

            if(!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            string indexFileName = dirName + "\\"+"Index.cshtml";
			string detailsFileName = dirName + "\\" + "Details.cshtml";
			File.WriteAllText(indexFileName, indexViewString);
			File.WriteAllText(detailsFileName, detailsViewString);
		}
        
    }
}
