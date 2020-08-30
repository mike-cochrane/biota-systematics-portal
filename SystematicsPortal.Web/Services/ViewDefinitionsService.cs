using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Services.Interfaces;

namespace SystematicsPortal.Web.Services
{
    public class ViewDefinitionsService : IViewDefinitionsService
    {
        public ViewDefinitionsService()
        {
        }

        public ViewDefinition Get()
        {
            var viewDefinition = new ViewDefinition();

            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Full Name", XPath = "Document/NameFull", Order = 20, Template = "Label" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Parent", XPath = "Document/Parent", Order = 10, Template = "NameHyperlink" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Authors", XPath = "Document/Authors", Order = 1, Template = "Label" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Classification", XPath = "Document/Classification", Order = 30, Template = "Label" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Reference", XPath = "Document/ParentReference", Order = 40, Template = "ReferenceHyperlink" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "CurrentName", XPath = "Document/CurrentName", Order = 50, Template = "NameHyperlink" });

            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Biostatus", XPath = "Document/BiostatusValues", Order = 60, Template = "Biostatus" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Concepts", XPath = "Document/Concepts", Order = 70, Template = "Concepts" });
            viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Siblings", XPath = "Document/Siblings", Order = 80, Template = "Siblings" });

            return viewDefinition;
        }
    }
}
