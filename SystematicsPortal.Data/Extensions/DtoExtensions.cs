using System.Linq;
using SystematicsPortal.Models.Entities.Database;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data.Extensions
{
    public static class DtoExtensions
    {
        public static Models.Entities.Access.ContentConfiguration ToDto(this ContentConfiguration contentConfigurationDb)
        {
            var contentConfigurationDto = new Models.Entities.Access.ContentConfiguration()
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
