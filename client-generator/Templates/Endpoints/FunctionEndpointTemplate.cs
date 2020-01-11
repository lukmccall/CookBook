﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by JetBrains T4 Processor
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace client_generator.Templates.Endpoints
{
    using System;
    #line 2 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
using System.Text;
    #line default
    #line hidden
    #line 3 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
using System.Collections.Generic;
    #line default
    #line hidden
    #line 4 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
using System.Linq;
    #line default
    #line hidden
    #line 5 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
using client_generator.Extensions;
    #line default
    #line hidden
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("JetBrains.ForTea.TextTemplating", "42.42.42.42")]
    public partial class FunctionEndpointTemplate : FunctionEndpointTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            this.Write("async ");
            
            #line 6 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_functionName));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 6 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", _signature)));
            
            #line default
            #line hidden
            this.Write("): Promise<");
            
            #line 6 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_returnTypes.StrJoin(" | ")));
            
            #line default
            #line hidden
            this.Write("> {\n    let _url = this.baseUrl + \"");
            
            #line 7 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_url));
            
            #line default
            #line hidden
            this.Write("\";\n");
            #line 8 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

    foreach (var code in _parameterParsingCodes)
    {
        foreach (var line in code.Split("\n"))
        {

            
            #line default
            #line hidden
            this.Write("    ");
            
            #line 14 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(line));
            
            #line default
            #line hidden
            this.Write("\n");
            #line 15 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

        }
    }

            
            #line default
            #line hidden
            this.Write(" \n    _url = _url.replace(/[?&]$/, \"\");\n\n    let _options = {\n");
            #line 22 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

    if (_haveBody)
    {

            
            #line default
            #line hidden
            this.Write("        body: _body,\n");
            #line 27 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("        method: \"");
            
            #line 30 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_type.ToString().ToUpper()));
            
            #line default
            #line hidden
            this.Write("\",\n        headers: {\n            \"Content-Type\": \"application/json\",\n            \"Accept\": \"application/json\"\n        }\n    };\n\n    let _response = await fetch(_url, _options);\n\n");
            #line 39 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

    foreach (var (status, response) in _responses)
    {

            
            #line default
            #line hidden
            this.Write("    if (_response.status === ");
            
            #line 43 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(status));
            
            #line default
            #line hidden
            this.Write(") {\n        ");
            
            #line 44 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(response));
            
            #line default
            #line hidden
            this.Write("\n");
            #line 45 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

        if (status.WasSuccessful())
        {

            
            #line default
            #line hidden
            this.Write("        return _data");
            
            #line 49 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(status));
            
            #line default
            #line hidden
            this.Write(";\n");
            #line 50 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

        }
        else
        {

            
            #line default
            #line hidden
            this.Write("        throw _data");
            
            #line 55 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(status));
            
            #line default
            #line hidden
            this.Write(";\n");
            #line 56 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("    }\n");
            #line 60 "/Users/lukasz/studies/cis/CookBook/client-generator/Templates/Endpoints/FunctionEndpointTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\n    // handling undefinded response\n    if (_response.status !== 200 && _response.status !== 204) {\n        throw new Error(\"An unexpected server error occurred.\");\n    }\n\n    return null;\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("JetBrains.ForTea.TextTemplating", "42.42.42.42")]
    public class FunctionEndpointTemplateBase
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
        protected System.Text.StringBuilder GenerationEnvironment
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