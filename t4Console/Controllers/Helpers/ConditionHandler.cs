using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using t4Console.Models;

namespace t4Console.Controllers.Helpers
{
	public class ConditionHandler
	{
        public ConditionHandler()
        {
            
        }
        public List<Field> GenerateConditions(List<Field> fields)
        {
			//(IncludedInBlktFromPrsnlProp[.='Yes']) or ((EQCovIndicatorFromPrsnlProp[.='Yes, Included in Blanket']) and (IncludedInBlktFromPrsnlProp[.='No']))
			for (int i = 0; i < fields.Count; i++)
			{
				var field = fields[i];
				if (field.DispCondition != null)
				{
					field.DispCondition = GenerateReqCondition(field);
					var VariableList = ExtractVariables(field);
				}
				if (field.ReqCondition != null)
				{
					var VariableList = ExtractVariables(field);
					field.ReqCondition = GenerateReqCondition(field);
				}
			}	
			return fields;
        }
        public string GenerateReqCondition(Field field)
        {
			var conditionString = field.ReqCondition;
			string cSharpCondition = conditionString;
			string varName = conditionString.Split("[.=")[0];
			
			conditionString = conditionString.Split(varName)[1];
			Console.WriteLine(varName);
			cSharpCondition = conditionString.Replace(".=", varName + " == ").Replace("'", "\"").Replace("[", "").Replace("]", "").Replace("or", " || ");
			cSharpCondition = "(" + cSharpCondition + ")";
			return cSharpCondition;

        }
		public List<string> ExtractVariables(Field field)
		{
			List<string> variableList = new List<string>();
			return variableList;
		}
	}
}
