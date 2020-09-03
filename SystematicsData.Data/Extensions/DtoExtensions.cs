using System.Linq;
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
                FieldGroupId = fieldGroupDb.FieldGroupId,
                DisplayOrder = fieldGroupDb.DisplayOrder,
                DisplayTitle = fieldGroupDb.DisplayTitle,
                DocumentClass = fieldGroupDb.DocumentClass,
                Name = fieldGroupDb.Name
                //FieldConfigurations = fieldGroupDb.FieldConfiguration.Select(fc => fc.ToDto()),
            };

            return fieldGroupDto;
        }

        public static FieldConfigurationDto ToDto(this FieldConfiguration fieldConfigurationDb)
        {
            var fieldConfigurationDto = new FieldConfigurationDto()
            {
                FieldConfigurationId = fieldConfigurationDb.FieldConfigurationId,
                DisplayOrder = fieldConfigurationDb.DisplayOrder,
                DataDocumentXpath = fieldConfigurationDb.DataDocumentXpath,
                DisplayAsIcon = fieldConfigurationDb.DisplayAsIcon,
                // Should the harvester process fill in the labels?
                //Labels = fieldConfigurationDb.Labels,
                ShowAlways = fieldConfigurationDb.ShowAlways
            };

            return fieldConfigurationDto;
        }
    }
}
