using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using System.Text;

namespace MyApi
{
    public class Diagnostic
    {
        public Diagnostic(string type, string code)
        {
            Type = type;
            Code = code;
        }

        public int? Character { get; protected set; }
        public string Code { get; }
        public string File { get; protected set; }
        public int? Line { get; protected set; }
        public string Message { get; protected set; }
        public string Type { get; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(File))
            {
                builder.Append(File);
                if (Line.HasValue)
                {
                    builder.AppendFormat("({0}", Line);
                    if (Character.HasValue)
                        builder.AppendFormat(",{0}", Character);
                    builder.Append(")");
                }

                builder.Append(": ");
            }

            builder.AppendFormat("{0} {1}", Type, Code);
            if (!string.IsNullOrWhiteSpace(Message))
                builder.AppendFormat(": {0}", Message);

            return builder.ToString();
        }

        protected void SetLocation(Location location)
        {
            var line = location.GetMappedLineSpan().StartLinePosition;

            File = location.GetMappedLineSpan().Path;
            Line = line.Line + 1;
            Character = line.Character + 1;
        }
    }

    public class Warning : Diagnostic
    {
        public Warning(string code) : base("warning", code) { }
    }

    public class Error : Diagnostic
    {
        public Error(string code) : base("error", code) { }
    }


    public class MissingMyApiSitePropertyAttributeWarning : Warning
    {
        public MissingMyApiSitePropertyAttributeWarning(InterfaceDeclarationSyntax @interface, PropertyDeclarationSyntax property)
            : base("RF001")
        {
            SetLocation(property.GetLocation());

            InterfaceName = @interface.Identifier.Text;
            PropertyName = property.Identifier.Text;

            Message = string.Format(
                "Method {0}.{1} either has no Refit HTTP method attribute or you've used something other than a string literal for the 'path' argument.",
                InterfaceName,
                PropertyName);
        }

        public string InterfaceName { get; }
        public string PropertyName { get; }
    }


    public class ReadOnlyFileError : Error
    {
        public ReadOnlyFileError(FileInfo file) : base("RF003")
        {
            File = file.FullName;
            Message = "File is marked as read-only and is not up-to-date.";
        }
    }
}
