using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace blogit.dal
{
    class GenerateTable
    {
        CodeCompileUnit targetUnit;

        CodeTypeDeclaration targetClass;

        //Class Name
        private const string outputFileName = "Mahsa.cs";

        public GenerateTable()
        {
            targetUnit = new CodeCompileUnit();

            //Path
            CodeNamespace samples = new CodeNamespace("blogit.dal.Entities");


            //Namespace
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            samples.Imports.Add(new CodeNamespaceImport("System.Linq"));
            samples.Imports.Add(new CodeNamespaceImport("System.Text"));
            samples.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));

            targetClass = new CodeTypeDeclaration("Mahsa");
            targetClass.IsClass = true;
            targetClass.TypeAttributes =
                TypeAttributes.Public | TypeAttributes.Sealed;
            samples.Types.Add(targetClass);
            targetUnit.Namespaces.Add(samples);
        }

        public void AddFields()
        {
            // Declare the ID Property.
            CodeMemberProperty IDProperty = new CodeMemberProperty();
            IDProperty.Attributes = MemberAttributes.Public;
            IDProperty.Name = "Id";
            IDProperty.HasGet = true;
            IDProperty.HasSet = true;
            IDProperty.Type = new CodeTypeReference(typeof(System.Int16));
            IDProperty.Comments.Add(new CodeCommentStatement(
            "Id is identity"));
            targetClass.Members.Add(IDProperty);

            // Declare the Name field
            CodeMemberField Name = new CodeMemberField();

            Name.Attributes = MemberAttributes.Public;
            Name.Name = "Name";
            Name.Type =
                new CodeTypeReference(typeof(System.String));
            //Name.Comments.Add(new CodeCommentStatement(
            //     "Name is string"));
            targetClass.Members.Add(Name);

        }
    }
}
