using Microsoft.CSharp;
using RTC_Vision_Lite.PublicFunctions;
using RTCConst;
using RTCEnums;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{

    public class cResult
    {
        public EExpressionResultTypes ResultType { get; set; }

        public bool bValue;

        public int iValue;

        public double dValue;

        public string sValue;
        public List<double> ldValue;
        public List<string> lsValue;
        public List<object> hValue;
        public Tuple<Point, double> tuple;

        public cResult(EExpressionResultTypes _ResultType = EExpressionResultTypes.Boolean)
        {
            ResultType = _ResultType;
            bValue = false;
            iValue = 0;
            dValue = 0;
            sValue = string.Empty;
            hValue = new List<object>();
        }
    }
    public class cExpression
    {
        private string _oldExpressionRun;

        public List<SStringBuilderItem> Operands
        { get;
          set; }

        private string _expression;

        public string Expression
        {
            get => _expression;
            set
            {
                _expression = value;
                _expressionOrigin = _expression;
                ErrCode = string.Empty;
                Operands = new List<SStringBuilderItem>();
                GetMathMemberNames();
                ExpressionStandardization();
                GetOperands();
            }
        }

        private string _expressionOrigin;

        public string ExpressionOrigin => _expressionOrigin;

        public string ErrCode { get; set; }

        public bool RunSuccess { get; set; }

        public bool IsCalculated { get; set; }

        public string CalculateMode { get; set; }

        public cResult Result { get; set; }

        private ArrayList _mathMembers = new ArrayList();

        private Hashtable _mathMembersMap = new Hashtable();

        private void GetMathMemberNames()
        {
            Assembly systemAssembly = Assembly.GetAssembly(typeof(Math));
            try
            {
                if(systemAssembly != null)
                {
                    Module[] modules = systemAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    foreach(Type type in types)
                    {
                        if(type.Name == "Math")
                        {
                            MemberInfo[] mis = type.GetMembers();
                            foreach(MemberInfo mi in mis)
                            {
                                _mathMembers.Add(mi.Name);
                                _mathMembersMap[mi.Name.ToUpper()] = mi.Name;
                            }
                        }
                    }
                }
            }
            catch
            {
                ErrCode = "Error: An exception occurred while executing the script";
            }
        }

        private void Replace(ref string _Value, string _FindText, string _RepText)
        {
            while(_Value.Contains(_FindText))
            {
                _Value = _Value.Replace(_FindText, _RepText);
            }
        }

        private void ExpressionStandardization()
        {
            _expression = _expression.Trim();
            Replace(ref _expression, "   ", " ");
            Replace(ref _expression, "===", "==");
            Replace(ref _expression, ">>", ">");
            Replace(ref _expression, "<<", "<");
            Replace(ref _expression, "++", "+");
            Replace(ref _expression, "+-", "-");
            Replace(ref _expression, "+*", "+");
            Replace(ref _expression, "+/", "+");
            Replace(ref _expression, "--", "+");
            Replace(ref _expression, "-+", "-");
            Replace(ref _expression, "-*", "-");
            Replace(ref _expression, "-/", "-");
            Replace(ref _expression, "*+", "*");
            Replace(ref _expression, "*-", "*");
            Replace(ref _expression, "**", "*");
            Replace(ref _expression, "*/", "*");
            Replace(ref _expression, "*x", "*");
            Replace(ref _expression, "/+", "/");
            Replace(ref _expression, "//", "/");
            Replace(ref _expression, "&&&", "&&");
            Replace(ref _expression, "|||", "||");
        }

        private void GetOperands()
        {
            List<SStringBuilderItem> OperandOlds = Operands;
            Regex regex = new Regex(string.Format("{0}(.*?){1}", Regex.Escape("\""), Regex.Escape("\"")), RegexOptions.RightToLeft);
            string newExpression = regex.Replace(_expression, "\"\"");

            Operands = new List<SStringBuilderItem>();
            SStringBuilderItem item = new SStringBuilderItem();
            Regex regularExpression = GetRegex();
            MatchCollection matches = regularExpression.Matches(newExpression);
            ArrayList replacelist = new ArrayList();

            List<string> operatorChars = new List<string>()
            {
                "%" , "/", "*", "+", "-", "sqrt",
                "sin", "cos", "tan", "min", "max", "pow", "pi", "abs",
                "like", "asin", "acos", "atan", "log", "log10", "round"};
            foreach(Match m in matches)
            {
                if (m.Value.StartsWith("\""))
                    continue;

                if (double.TryParse(m.Value, out double d))
                    continue;

                int indexOf = operatorChars.IndexOf(m.Value.ToLower());
                if(indexOf >= 0)
                {
                    if (operatorChars[indexOf].ToLower() == "like")
                        continue;
                    if (indexOf >= 5)
                        _expression = _expression.Replace(m.Value, "Math." + GlobFuncs.FirstCharToUpper(operatorChars[operatorChars.IndexOf(m.Value.ToLower())]));
                    continue;
                }

                bool isContainedInMathLibrary = _mathMembersMap[m.Value.ToUpper()] != null;
                if(replacelist.Contains(m.Value) == false && isContainedInMathLibrary)
                {
                    _expression = _expression.Replace(m.Value, "Math." + _mathMembersMap[m.Value.ToUpper()]);
                }
                else
                {
                    item = new SStringBuilderItem();
                    item.ValueStyle = EHTupleStyle.Real;
                    string sNewValue = m.Value;

                    if(m.Value.ToLower().EndsWith(cSuffixExpressionOperand.Boolean) && m.Value.ToLower() != cSuffixExpressionOperand.Boolean)
                    {
                        sNewValue = sNewValue.Substring(0, sNewValue.Length - cSuffixExpressionOperand.Boolean.Length);
                        item.ValueStyle = EHTupleStyle.Boolean;
                        _expression = _expression.Replace(m.Value, sNewValue);
                    }
                    else if(m.Value.ToLower().EndsWith(cSuffixExpressionOperand.Integer) && m.Value.ToLower() != cSuffixExpressionOperand.Integer)
                    {
                        sNewValue = sNewValue.Substring(0, sNewValue.Length - cSuffixExpressionOperand.Integer.Length);
                        item.ValueStyle = EHTupleStyle.Integer;
                        _expression = _expression.Replace(m.Value, sNewValue);
                    }
                    else if (m.Value.ToLower().EndsWith(cSuffixExpressionOperand.Real) && m.Value.ToLower() != cSuffixExpressionOperand.Real)
                    {
                        sNewValue = sNewValue.Substring(0, sNewValue.Length - cSuffixExpressionOperand.Real.Length);
                        item.ValueStyle = EHTupleStyle.Real;

                        _expression = _expression.Replace(m.Value, sNewValue);
                    }
                    else if (m.Value.ToLower().EndsWith(cSuffixExpressionOperand.String) && m.Value.ToLower() != cSuffixExpressionOperand.String)
                    {
                        sNewValue = sNewValue.Substring(0, sNewValue.Length - cSuffixExpressionOperand.String.Length);
                        item.ValueStyle = EHTupleStyle.String;
                        _expression = _expression.Replace(m.Value, sNewValue);
                    }
                    else if (m.Value.ToLower().EndsWith(cSuffixExpressionOperand.Tuple) && m.Value.ToLower() != cSuffixExpressionOperand.Tuple)
                    {
                        sNewValue = sNewValue.Substring(0, sNewValue.Length - cSuffixExpressionOperand.Tuple.Length);
                        _expression = _expression.Replace(m.Value, sNewValue);


                    }
                    item.Name = sNewValue;

                    SStringBuilderItem itemOld = null;
                    if (OperandOlds != null)
                        itemOld = OperandOlds.Find(x => x.Name == sNewValue);
                    if (itemOld == null)
                    {
                        if (Operands.FirstOrDefault((x => x.Name.ToLower() == sNewValue.ToLower())) == null)
                            Operands.Add(item);
                    }
                    else if (Operands.FirstOrDefault((x => x.Name.ToLower() == itemOld.Name.ToLower())) == null)
                        Operands.Add(itemOld);

                    replacelist.Add(m.Value);
                }
            }
        }

        //public void Calculate()
        //{
        //    try
        //    {
        //        SetDefaultValueToResult();
        //        string _ExpressionRun = Expression;

        //        foreach(SStringBuilderItem _Operand in Operands)
        //        {
        //            switch()
        //        }
        //    }
        //}

        private void SetDefaultValueToResult()
        {
            switch(Result.ResultType)
            {
                case EExpressionResultTypes.Boolean:
                    Result.bValue = false;
                    break;
                case EExpressionResultTypes.Integer:
                    Result.iValue = 0;
                    break;
                case EExpressionResultTypes.Double:
                    Result.dValue = 0;
                    break;
                case EExpressionResultTypes.String:
                    Result.sValue = string.Empty;
                    break;
                default:
                    break;
            }
        }

        private Regex GetRegex()
        {
            Regex regularExpression1 = new Regex("[\"a-zA-Z0-9_]+");
            return regularExpression1;

            MatchCollection matches1 = regularExpression1.Matches(_expression);
            foreach(Match m in matches1)
            {
                Regex regularExpression2 = new Regex("(?<![S\"])([^\"s]+)(?![S\"])");
                MatchCollection matches2 = regularExpression2.Matches(m.Value);
                ArrayList replacelist2 = new ArrayList();
            }

            Regex regularExpression = new Regex("[\"a-zA-Z0-9_]+(?<![S\"])([^\"s]+)(?![S\"])");

            MatchCollection matches = regularExpression.Matches(_expression);
            ArrayList replacelist = new ArrayList();

            return regularExpression;
        }

        public cExpression(string _ExpressionInput, string caculateMode = cCaculateMode.ByDataTable,
        EExpressionResultTypes _ResultType = EExpressionResultTypes.Boolean,
        bool _IsRun = true)
        {
            _expressionOrigin = _ExpressionInput;
            _expression = _ExpressionInput;
            Result = new cResult(_ResultType);
            ErrCode = string.Empty;
            _oldExpressionRun = string.Empty;
            RunSuccess = false;
            IsCalculated = false;
            CalculateMode = caculateMode;
            Operands = new List<SStringBuilderItem>();
            if (_IsRun)
            {
                GetMathMemberNames();
                ExpressionStandardization();
                GetOperands();
                Calculate();
            }
        }
        public void SetNewExpression(string newExpression,
            string calculateMode = cCaculateMode.ByDataTable,
            EExpressionResultTypes resultTypes = EExpressionResultTypes.Boolean)
        {
            _expressionOrigin = newExpression;
            _expression = newExpression;
            if(!IsCalculated)
            {
                Result = new cResult(resultTypes);
                ErrCode = string.Empty;
            }
            GetMathMemberNames();
            ExpressionStandardization();
            GetOperands();
            Calculate();
        }

        public void Calculate()
        {
            try
            {
                SetDefaultValueToResult();
                string _ExpressionRun = Expression;
                foreach (SStringBuilderItem _Operand in Operands)
                {
                    if (_Operand.ListDoubleValue.Count <= 0 && _Operand.ListStringValue == null)
                    {
                        IsCalculated = false;
                        RunSuccess = false;
                        return;
                    }
                    switch (_Operand.ValueStyle)
                    {
                        case EHTupleStyle.Boolean:
                            ReplaceOperand(ref _ExpressionRun, _Operand.Name, GlobFuncs.Ve2Bool(_Operand.ListStringValue[0]).ToString().ToLower());
                            break;
                        case EHTupleStyle.Integer:
                            ReplaceOperand(ref _ExpressionRun, _Operand.Name, GlobFuncs.Ve2Interger(_Operand.ListDoubleValue[0]).ToString().ToLower());
                            break;
                        case EHTupleStyle.String:
                            ReplaceOperand(ref _ExpressionRun, _Operand.Name, "\"" + _Operand.ListStringValue[0] + "\"");
                            break;
                        case EHTupleStyle.Real:
                            ReplaceOperand(ref _ExpressionRun, _Operand.Name, GlobFuncs.Ve2Double(_Operand.ListDoubleValue[0])[0].ToString().ToLower());
                            break;
                            
                    }
                }

                IsCalculated = false;
                RunSuccess = false;

                switch (CalculateMode)
                {
                    case cCalculateMode.ByCode:
                        {
                            Replace(ref _ExpressionRun, "\"\"", "\"");
                            BuildClass(_ExpressionRun);

                            CompilerResults results = CompileAssembly();

                            if (results != null && results.CompiledAssembly != null)
                            {
                                RunCode(results);
                                RunSuccess = true;
                                IsCalculated = true;
                            }

                            break;
                        }
                    case cCalculateMode.ByExcel:
                        {

                            Replace(ref _ExpressionRun, "==", "=");
                            Replace(ref _ExpressionRun, "!true", "false");
                            Replace(ref _ExpressionRun, "!false", "true");

                            break;
                        }
                    default:
                        {
                            Replace(ref _ExpressionRun, "==", "=");
                            Replace(ref _ExpressionRun, "||", " OR ");
                            Replace(ref _ExpressionRun, "&&", " AND ");
                            //Replace(ref _ExpressionRun, "!", "");
                            Replace(ref _ExpressionRun, "!true", "false");
                            Replace(ref _ExpressionRun, "!false", "true");
                            Replace(ref _ExpressionRun, "\"\"", "''");
                            Replace(ref _ExpressionRun, "\"\"", "\"");
                            Replace(ref _ExpressionRun, "\"\"", "");
                            Replace(ref _ExpressionRun, "\"", "'");


                            var result = new System.Data.DataTable().Compute(_ExpressionRun, "");

                            if (result != null)
                            {
                                switch (Result.ResultType)
                                {
                                    case EExpressionResultTypes.Boolean:
                                        if (!bool.TryParse(result.ToString(), out Result.bValue))
                                            Result.bValue = false;
                                        break;
                                    case EExpressionResultTypes.Integer:
                                        if (!int.TryParse(result.ToString(), out Result.iValue))
                                            Result.iValue = 0;
                                        break;
                                    case EExpressionResultTypes.Double:
                                        if (!double.TryParse(result.ToString(), out Result.dValue))
                                            Result.dValue = 0;
                                        break;
                                    case EExpressionResultTypes.String:
                                        Result.sValue = result.ToString();
                                        break;
                                    case EExpressionResultTypes.HTuple:
                                        if (bool.TryParse(result.ToString(), out Result.bValue))
                                            Result.hValue = new List<object>() { Result.bValue.ToString() };
                                        else if (int.TryParse(result.ToString(), out Result.iValue))
                                            Result.hValue = new List<object>() { Result.iValue };
                                        else if (double.TryParse(result.ToString(), out Result.dValue))
                                            Result.hValue = new List<object>() { Result.dValue };
                                        else
                                            Result.hValue = new List<object>() { result.ToString() };
                                        break;
                                    default:
                                        break;
                                }
                            }
                            RunSuccess = true;
                            IsCalculated = true;
                            break;
                        }
                }
            }


            catch (Exception ex)
            {

            }
        }
        StringBuilder _source = new StringBuilder();
        private CompilerResults CompileAssembly()
        {
            // create a compiler
            ICodeCompiler compiler = CreateCompiler();
            // get all the compiler parameters
            CompilerParameters parms = CreateCompilerParameters();
            // compile the code into an assembly
            CompilerResults results = CompileCode(compiler, parms, _source.ToString());
            return results;

        }
        ICodeCompiler CreateCompiler()
        {
            //Create an instance of the C# compiler   
            CodeDomProvider codeProvider = null;
            codeProvider = new CSharpCodeProvider();
            ICodeCompiler compiler = codeProvider.CreateCompiler();
            return compiler;
        }
        CompilerParameters CreateCompilerParameters()
        {
            //add compiler parameters and assembly references
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            //add any aditional references needed
            //            foreach (string refAssembly in code.References)
            //              compilerParams.ReferencedAssemblies.Add(refAssembly);

            return compilerParams;
        }
        private void RunCode(CompilerResults results)
        {
            RunSuccess = false;
            switch (Result.ResultType)
            {
                case EExpressionResultTypes.Boolean:
                    Result.bValue = false;
                    break;
                case EExpressionResultTypes.Integer:
                    Result.iValue = 0;
                    break;
                case EExpressionResultTypes.Double:
                    Result.dValue = 0;
                    break;
                case EExpressionResultTypes.String:
                    Result.sValue = string.Empty;
                    break;
                case EExpressionResultTypes.HTuple:
                    Result.lsValue = new List<string>();
                    Result.ldValue = new List<double>();
                    break;
                default:
                    break;
            }

            Assembly executingAssembly = results.CompiledAssembly;
            try
            {
                //cant call the entry method if the assembly is null
                if (executingAssembly != null)
                {
                    object assemblyInstance = executingAssembly.CreateInstance("ExpressionEvaluator.Calculator");
                    //Use reflection to call the static Main function

                    Module[] modules = executingAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types)
                    {
                        MethodInfo[] mis = type.GetMethods();
                        foreach (MethodInfo mi in mis)
                        {
                            if (mi.Name == "Calculate")
                            {
                                object result = mi.Invoke(assemblyInstance, null);
                                if (result == null) return;
                                switch (Result.ResultType)
                                {
                                    case EExpressionResultTypes.Boolean:
                                        if (!bool.TryParse(result.ToString(), out Result.bValue))
                                            Result.bValue = false;
                                        break;
                                    case EExpressionResultTypes.Integer:
                                        if (!int.TryParse(result.ToString(), out Result.iValue))
                                            Result.iValue = 0;
                                        break;
                                    case EExpressionResultTypes.Double:
                                        if (!double.TryParse(result.ToString(), out Result.dValue))
                                            Result.dValue = 0;
                                        break;
                                    case EExpressionResultTypes.String:
                                        Result.sValue = result.ToString();
                                        break;
                                    case EExpressionResultTypes.HTuple:
                                        if (bool.TryParse(result.ToString(), out Result.bValue))
                                            Result.lsValue = new List<string>() { Result.bValue.ToString() };
                                        else if (int.TryParse(result.ToString(), out Result.iValue))
                                            Result.ldValue = new List<double>() { Result.iValue };
                                        else if (double.TryParse(result.ToString(), out Result.dValue))
                                            Result.ldValue = new List<double>() { Result.dValue };
                                        else
                                            Result.lsValue = new List<string>() { result.ToString() };
                                        break;
                                    default:
                                        break;
                                }

                                RunSuccess = true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrCode = "Error:  An exception occurred while executing the script\n" + ex.Message;
            }

        }
        private CompilerResults CompileCode(ICodeCompiler compiler, CompilerParameters parms, string source)
        {
            //actually compile the code
            CompilerResults results = compiler.CompileAssemblyFromSource(
                                        parms, source);

            //Do we have any compiler errors?
            if (results.Errors.Count > 0)
                return null;

            return results;
        }
        CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel)
        {
            CodeMemberField field = new CodeMemberField(type, fieldName);
            field.Attributes = accessLevel;
            return field;
        }
        CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type)
        {
            CodeMemberProperty myProperty = new CodeMemberProperty();
            myProperty.Name = propertyName;
            myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
            myProperty.Attributes = MemberAttributes.Public;
            myProperty.Type = new CodeTypeReference(type);
            myProperty.HasGet = true;
            myProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

            myProperty.HasSet = true;
            myProperty.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName),
                    new CodePropertySetValueReferenceExpression()));

            return myProperty;
        }
        private void ReplaceOperand(ref string _Value, string _FindText, string _RepText)
        {
            string pattern = "\\b" + _FindText + "\\b";
            _Value = Regex.Replace(_Value, pattern, _RepText);
        }
        void BuildClass(string expression)
        {
            // need a string to put the code into
            _source = new StringBuilder();
            StringWriter sw = new StringWriter(_source);

            //Declare your provider and generator
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeGenerator generator = codeProvider.CreateGenerator(sw);
            CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

            CodeNamespace myNamespace = new CodeNamespace("ExpressionEvaluator");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

            //Build the class declaration and member variables			
            CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
            classDeclaration.IsClass = true;
            classDeclaration.Name = "Calculator";
            classDeclaration.Attributes = MemberAttributes.Public;
            classDeclaration.Members.Add(FieldVariable("answer", typeof(object), MemberAttributes.Private));

            //default constructor
            CodeConstructor defaultConstructor = new CodeConstructor();
            defaultConstructor.Attributes = MemberAttributes.Public;
            defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
            defaultConstructor.Statements.Add(new CodeSnippetStatement("//TODO: implement default constructor"));
            classDeclaration.Members.Add(defaultConstructor);

            //property
            classDeclaration.Members.Add(this.MakeProperty("Answer", "answer", typeof(object)));

            //Our Calculate Method
            CodeMemberMethod myMethod = new CodeMemberMethod();
            myMethod.Name = "Calculate";
            myMethod.ReturnType = new CodeTypeReference(typeof(object));
            myMethod.Comments.Add(new CodeCommentStatement("Calculate an expression", true));
            myMethod.Attributes = MemberAttributes.Public;
            myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression(expression)));
            //            myMethod.Statements.Add(new CodeSnippetExpression("MessageBox.Show(String.Format(\"Answer = {0}\", Answer))"));
            myMethod.Statements.Add(
                new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
            classDeclaration.Members.Add(myMethod);
            //write code
            myNamespace.Types.Add(classDeclaration);
            generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
            sw.Flush();
            sw.Close();
        }

    }

    public enum EExpressionResultTypes
    {
        Boolean = 0,
        Integer = 1,
        Double = 2,
        String = 3,
        HTuple = 4
    }

    public class cSuffixExpressionOperand
    {
        public const string Boolean = "_b";
        public const string Integer = "_i";
        public const string Real = "_r";
        public const string String = "_s";
        public const string Tuple = "_t";
    }
    
}
