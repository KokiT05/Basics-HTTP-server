using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

namespace MyServer.MvcFramework.ViewEngines
{
    public class ViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel)
        {
            string csharpCode = GenerateCSharpFromTemplate(templateCode);
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
            string html = executableObject.GetHtml(viewModel);
            return html;
        }

        private string GenerateCSharpFromTemplate(string templateCode)
        {
            string methodBody = GetMethodBody(templateCode);
            string csharpCode = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyServer.MvcFramework.ViewEngines;

namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string GetHtml(object viewModel)
        {
            StringBuilder html = new StringBuilder();

                " + methodBody + @"
                
            return html.ToString();
        }
    }
}";
            return csharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            throw new NotImplementedException();
        }

        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            var compliteResult = CSharpCompilation.Create("ViewAssembly")
                                 .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                                 .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                                 .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

            if (viewModel != null)
            {
                compliteResult = compliteResult.AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            var libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();

            foreach (var library in libraries)
            {
                compliteResult = compliteResult.AddReferences(MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            compliteResult = compliteResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                EmitResult result= compliteResult.Emit(memoryStream);

                if (!result.Success)
                {
                    //compile errors!!!
                    return new ErrorView(result.Diagnostics.Where(e => e.Severity == DiagnosticSeverity.Error)
                        .Select(e => e.GetMessage()).ToList(), csharpCode);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                byte[] byteAssebly = memoryStream.ToArray();
                Assembly assembly = Assembly.Load(byteAssebly);
                Type viewType = assembly.GetType("ViewNamespace.ViewClass");
                Object instance = Activator.CreateInstance(viewType);

                memoryStream.Dispose();
                memoryStream.Close();

                return instance as IView;

            }
        }

    }
}
