using System.Collections.Generic;
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

            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Classification", XPath = "Document/Classification", Order = 30, Template = "Label" });
            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Reference", XPath = "Document/ParentReference", Order = 40, Template = "ReferenceHyperlink" });
            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Heading", XPath = "Document", Order = 10, Template = "Heading" });

            // var fieldDefinition = new FieldDefinition()
            // {
            //     Label = "Biostatus Values",
            //     XPath = "Document/BiostatusValues",
            //     Order = 60,
            //     Template = "Biostatus"
            // };

            // if (true)
            // {
            //     fieldDefinition.DataLabels = new Dictionary<string, string>() {
            //                 {"//Document/BiostatusValue[@isActive='true']", "Biostatus"},
            //                 {"//Document/BiostatusValue[@isActive='true']/Occurrence", "Occurence"},
            //                 {"//Document/BiostatusValue[@isActive='true']/Georegion", "Georegion"}
            //             };
            // }
            // else
            // {
            //     fieldDefinition.Label = "Valores de bioestado";

            //     fieldDefinition.DataLabels = new Dictionary<string, string>() {
            //             {"//Document/BiostatusValue[@isActive='true']", "Bioestado"},
            //             {"//Document/BiostatusValue[@isActive='true']/Occurrence", "Ocurrencia"},
            //             {"//Document/BiostatusValue[@isActive='true']/Georegion", "Georregión"}
            //         };
            // }

            // viewDefinition.FieldDefinitions.Add(fieldDefinition);

            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Concepts", XPath = "Document/Concepts", Order = 70, Template = "Concepts" });
            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Siblings", XPath = "Document/Siblings", Order = 80, Template = "Siblings" });
            // viewDefinition.FieldDefinitions.Add(new FieldDefinition() { Label = "Collections", XPath = "Document/CollectionObjects", Order = 90, Template = "Collections" });


            var nomenclatureDefinition = new FieldDefinition() {
                Label = "Nomenclature",
                XPath = "Document/NomenclaturalStatusValues",
                Order = 100,
                Template = "DetailsStandard"
            };
            
            // nomenclatureDefinition.FieldConfigurations.Add(new FieldConfiguration() { Label = "Place of Publication", XPath = "NomenclaturalStatusValues/PublicationPlace", Order = 10, Template = "FormattedText" });
            // nomenclatureDefinition.FieldConfigurations.Add(new FieldConfiguration() { Label = "Publication Date (Actual)", XPath = "NomenclaturalStatusValues/PublicationPlace", Order = 20, Template = "FormattedText" });
            // nomenclatureDefinition.FieldConfigurations.Add(new FieldConfiguration() { Label = "Publication Date (Stated)", XPath = "NomenclaturalStatusValues/PublicationDateActual", Order = 30, Template = "FormattedText" });
            nomenclatureDefinition.FieldConfigurations.Add(new FieldConfiguration() { Label = "Nomenclatural Status", XPath = "NomenclaturalStatus/Comment", Order = 10, Template = "FormattedText" });
            
            viewDefinition.FieldDefinitions.Add(nomenclatureDefinition);    


            return viewDefinition;
        }
    }
}
