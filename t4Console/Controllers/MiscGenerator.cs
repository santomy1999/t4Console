using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using t4Console.Models;
using t4Console.Templates;

namespace t4Console.Controllers
{
	public class MiscGenerator
	{
		public MiscGenerator() { }
		public static async Task DropDownModelGenerator()
		{
			var dropdownModel = new DropDownModelTemplate()
			{
				ProjectName = ProjectData.ProjectName
			};
			var dropDownModelString = dropdownModel.TransformText();
			string dirName = ProjectData.getModelSaveLocation();

			string fileName = dirName + "DropDownModel.cs";

			File.WriteAllText(fileName, dropDownModelString);
		}
	}
}
