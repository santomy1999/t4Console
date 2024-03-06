using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t4Console.Controllers.Helpers;
using t4Console.Models;
using t4Console.Repository;
using t4Console.Templates;

namespace t4Console.Controllers
{
    public class ViewGenerator
    {
        private readonly FieldRepo _fieldRepo;
        private readonly ConditionHandler _conditionHandler;
        public ViewGenerator(CGDBContext cgdbContext) 
        {
            _fieldRepo = new FieldRepo(cgdbContext);
            _conditionHandler = new ConditionHandler();
        }
        public async Task GenerateView(Page page,Page? Previous, Page? Next)
        {
            var fields = await _fieldRepo.getFields(page.PageId);
            fields = _conditionHandler.GenerateConditions(fields);
            var domainValues = await _fieldRepo.GetPageDomains(page.PageId);
            var scriptTemplateString = await GenerateScripts(page);
            
			var sd = string.IsNullOrEmpty(scriptTemplateString) ? scriptTemplateString : "";
			var indexView = new View_Index_Template()
            {
                ProjectName = ProjectData.ProjectName,
                page = page,
                Name = page.PageTitle,
                fields= fields,
                domainValues = domainValues,
                NextPage = Next,
                PreviousPage = Previous,
				ScriptTemplateString = scriptTemplateString
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
        public async Task<string> GenerateScripts(Page page)
        {
			var fields = await _fieldRepo.getRequiredConditionFields(page.PageId);
            if(!fields.Any())
            {
                return null;
            }
			var scriptTemplate = new ScriptTemplate()
			{
				fields = fields
			};
			var scriptTemplateString = scriptTemplate.TransformText();
            return scriptTemplateString;
		}
    }
}
