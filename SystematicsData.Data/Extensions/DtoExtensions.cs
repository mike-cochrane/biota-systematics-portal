using SystematicsData.Data.Models;
using SystematicsData.Models.Entities.Access;

namespace SystematicsData.Data.Extensions
{
    public static class DtoExtensions
    {
        public static SystematicsData.Models.Entities.Access.ContentConfiguration ToDto(this Models.ContentConfiguration contentConfigurationDb)
        {
            var contentConfigurationDto = new SystematicsData.Models.Entities.Access.ContentConfiguration()
            {
                ContentConfigurationId = contentConfigurationDb.ContentConfigurationId,
                DisplayOrder = contentConfigurationDb.DisplayOrder,
                ExternalId = contentConfigurationDb.ExternalId,
                Page = contentConfigurationDb.Page,
                Section = contentConfigurationDb.Section,
                SectionTitle = contentConfigurationDb.SectionTitle
            };

            return contentConfigurationDto;
        }

        public static FieldGroupDto ToDto(this FieldGroup fieldGroupDb)
        {
            var fieldGroupDto = new FieldGroupDto()
            {
                DisplayTitle = fieldGroupDb.DisplayTitle,
                Name = fieldGroupDb.Name,
                DisplayOrder = fieldGroupDb.DisplayOrder
            };

            return fieldGroupDto;
        }

        public static FieldConfigurationDto ToDto(this FieldConfiguration fieldConfigurationDb)
        {
            var fieldConfigurationDto = new FieldConfigurationDto()
            {
                DataDocumentXpath = fieldConfigurationDb.DataDocumentXpath,
                SiblingFilterXPath = fieldConfigurationDb.SiblingFilterXpath,
                DisplayOrder = fieldConfigurationDb.DisplayOrder,
                DisplayTemplate = fieldConfigurationDb.DisplayTemplate,
                DisplayAsIcon = fieldConfigurationDb.DisplayAsIcon,
                ShowAlways = fieldConfigurationDb.ShowAlways
            };

            return fieldConfigurationDto;
        }
    }
}
