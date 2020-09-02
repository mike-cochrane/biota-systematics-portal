using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using SystematicsPortal.Web.Models;

namespace SystematicsPortal.Web.Services
{
    public static class ViewGenerationService
    {
        public static List<Field> Generate(XDocument document, ViewDefinition viewDefinition)
        {
            var fields = new List<Field>();
            var navigator = document.ToXPathNavigable().CreateNavigator();

            foreach (var fieldDefinition in viewDefinition.FieldDefinitions.OrderBy(o => o.Order))
            {
                var field = new Field();

                field.Label = fieldDefinition.Label;

                var rootNode = navigator.SelectSingleNode(fieldDefinition.XPath);

                if (rootNode != null)
                {
                    field.FieldData = new FieldData()
                    {
                        Data = XElement.Parse(rootNode.OuterXml),
                        DataLabels = fieldDefinition.DataLabels
                    };
                }

                field.ViewComponent = fieldDefinition.Template;

                fields.Add(field);
            }

            return fields;
        }
    }
}
