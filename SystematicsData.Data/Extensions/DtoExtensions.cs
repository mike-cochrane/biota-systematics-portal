using SystematicsData.Data.Models;

namespace SystematicsData.Data.Extensions
{
    public static class DtoExtensions
    {
        public static SystematicsData.Models.Entities.Access.ContentConfiguration ToDto(this ContentConfiguration contentConfigurationDb)
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
    }
}
