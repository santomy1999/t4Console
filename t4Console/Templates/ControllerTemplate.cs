﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace t4Console.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using t4Console.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ControllerTemplate : ControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 7 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"

	var domainsFields = fields.Where(f => f.FieldType == "select").OrderBy(d => d.Sequence).ToList();

            
            #line default
            #line hidden
            this.Write("using Microsoft.AspNetCore.Mvc;\r\nusing System.Diagnostics;\r\nusing ");
            
            #line 12 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectName));
            
            #line default
            #line hidden
            this.Write(".Models;\r\nusing ");
            
            #line 13 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectName));
            
            #line default
            #line hidden
            this.Write(".Models.DomainModels;\r\nusing Microsoft.AspNetCore.Mvc.Rendering;\t\r\nnamespace ");
            
            #line 15 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectName));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n\tpublic class ");
            
            #line 17 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(page.PageIdentifier));
            
            #line default
            #line hidden
            this.Write("Controller: Controller\r\n\t{\r\n\t\tpublic ");
            
            #line 19 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(page.PageIdentifier));
            
            #line default
            #line hidden
            this.Write("Controller()\r\n\t\t{\r\n\t\t}\r\n\r\n\t\tpublic IActionResult Index()\r\n\t\t{\r\n\t\t\tvar _model = ne" +
                    "w ");
            
            #line 25 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(page.PageIdentifier));
            
            #line default
            #line hidden
            this.Write("Model();\r\n");
            
            #line 26 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"

			foreach(var field in domainsFields)
			{
				var varName = field.FieldName.ToLower();

            
            #line default
            #line hidden
            this.Write("\t\t\tvar ");
            
            #line 31 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("List = ");
            
            #line 31 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write("Domains.GetAll();\r\n\r\n\t\t\t_model.");
            
            #line 33 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write("SelectList = new List<SelectListItem>();\r\n\r\n\t\t\tforeach (var ");
            
            #line 35 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" in ");
            
            #line 35 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("List)\r\n\t\t\t{\r\n\t\t\t\t_model.");
            
            #line 37 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write("SelectList.Add(new SelectListItem { Text = ");
            
            #line 37 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(".Text, Value = ");
            
            #line 37 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(".Value });\r\n\t\t\t}\r\n");
            
            #line 39 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"

			}

            
            #line default
            #line hidden
            this.Write("\t\t\treturn View();\r\n\t\t}\r\n\t\tpublic IActionResult Details( ");
            
            #line 44 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(page.PageIdentifier));
            
            #line default
            #line hidden
            this.Write("Model _model)\r\n\t\t{\r\n\t\t\t\r\n\t\t\tif (!ModelState.IsValid)\r\n\t\t\t{\r\n\t\t\t\treturn BadRequest" +
                    "(\"Data Invalid\");\r\n\t\t\t}\r\n");
            
            #line 51 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"

			foreach(var field in domainsFields)
			{
				var varName = field.FieldName.ToLower();

            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n\t\t\tvar ");
            
            #line 56 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("Option = ");
            
            #line 56 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write("Domains.GetDropDown(_model.");
            
            #line 56 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write(");\r\n\t\t\t_model.");
            
            #line 57 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(field.FieldName));
            
            #line default
            #line hidden
            this.Write("SelectList.Add(new SelectListItem { Text = ");
            
            #line 57 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("Option.Text , Value = ");
            
            #line 57 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("Option.Value });\r\n");
            
            #line 58 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"

			}

            
            #line default
            #line hidden
            this.Write(@"			return View(_model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	}
}
");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 71 "D:\Codegen\t4Console\t4Console\Templates\ControllerTemplate.tt"
 
	public string Name { get; set; }
	public string ProjectName { get; set; }
	public Page page { get; set; }
	public List<Field> fields { get; set; }

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class ControllerTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
