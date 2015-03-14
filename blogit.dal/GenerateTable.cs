using System;
using System.CodeDom;
using System.Reflection;

namespace BlogIT.Dal
{
    internal class GenerateTable
    {
        //Class Name
        private const string OutputFileName = "Mahsa.cs";
        private readonly CodeTypeDeclaration _targetClass;

        public GenerateTable()
        {
            var targetUnit = new CodeCompileUnit();

            //Path
            var samples = new CodeNamespace("BlogIT.Dal.Entities");


            //Namespace
            samples.Imports.Add(new CodeNamespaceImport("System"));
            samples.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            samples.Imports.Add(new CodeNamespaceImport("System.Linq"));
            samples.Imports.Add(new CodeNamespaceImport("System.Text"));
            samples.Imports.Add(new CodeNamespaceImport("System.Threading.Tasks"));

            _targetClass = new CodeTypeDeclaration("Mahsa")
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed
            };
            samples.Types.Add(_targetClass);
            targetUnit.Namespaces.Add(samples);
        }

        public void AddFields()
        {
            // Declare the ID Property.
            var idProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public,
                Name = "Id",
                HasGet = true,
                HasSet = true,
                Type = new CodeTypeReference(typeof(Int16))
            };

            idProperty.Comments.Add(new CodeCommentStatement(
                "Id is identity"));
            _targetClass.Members.Add(idProperty);

            // Declare the Name field
            var name = new CodeMemberField
            {
                Attributes = MemberAttributes.Public,
                Name = "Name",
                Type = new CodeTypeReference(typeof(String))
            };

            //Name.Comments.Add(new CodeCommentStatement(
            //     "Name is string"));
            _targetClass.Members.Add(name);
        }
    }
}