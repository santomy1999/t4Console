using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

			for (int i = 0; i < fields.Count; i++)
			{
				var field = fields[i];
				if (field.DispCondition != null)
				{
					field.DispCondition=field.DispCondition.Replace("[.", "").Replace("]", "").Replace("'","\"");
					fields[i] = field;
				}
				
			}
			return fields;
        }
        public Field GenerateReqCondition(Field field)
        {
            return field;
        }
		public Field GenerateDispCondition(Field field)
		{
			return field;
		}
	}
}
