namespace SystematicsPortal.Web.Models
{
    public class FieldDefinition
    {
        public string Label { get; set; }

        public string XPath { get; set; }

        public int Order { get; set; }

        public string Template { get; set; }

        public FieldDefinition()
        {
        }
    }
}
