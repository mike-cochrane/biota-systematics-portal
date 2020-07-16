using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Entities.Annotations;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Services
{
    public class HarvesterService
    {
        public readonly AnnotationsClient _client;
        public HarvesterService(AnnotationsClient client)
        {
            _client = client;
        }
        public async Task StartAsync()
        {
            // TODO: Listen for a message


            var resourceId = "C7EA0FE3-40A4-453A-BBB8-9F1AAF6673D7";
            var itemTypeId = "299B3954-6119-4265-AD5E-799CB7F53DE6";
            var itemId = "8F766C02-BD56-4B9A-BB35-27ED8F2E1826";


           var fields =await GetFieldsConfigurationAsync(resourceId, itemTypeId, itemId);




        }

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }

        private async Task<IEnumerable<Item>> GetFieldsConfigurationAsync(string resourceId, string itemTypeId, string itemId)
        {

            var items = await _client.GetItemsByIds(new List<string>() { itemId });

            var foundItem = items.ItemsList[0];

            if(foundItem == null)
            {
                throw new Exception($"Item {itemId} has not been found");
            }

            var relatedItemsIds = foundItem.relatedItems.Select(x => x.RelatedItemId).ToList();

            var relatedItems = await _client.GetItemsByIds(relatedItemsIds);

            return relatedItems.ItemsList;
        }
    }
}
