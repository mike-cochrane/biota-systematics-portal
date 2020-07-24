using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SystematicsPortal.Data.Harvester.Clients;
using SystematicsPortal.Models.Configuration;
using SystematicsPortal.Models.Interfaces;
using SystematicsPortal.Utility.Helpers;

namespace SystematicsPortal.Data.Harvester.Classes
{
    public class StaticContentReceiver :IHarvesterActionReceiver
    {
        public readonly AnnotationsClient _client;
        private readonly ILogger<StaticContentReceiver> _logger;

        public StaticContentReceiver(AnnotationsClient client, ILogger<StaticContentReceiver> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<XElement>> GetDocumentsAsync(string resourceId, string itemTypeId, string itemId)
        {
            var itemIds = (await _client.GetItemIds(itemTypeId)).ItemsList.Select(item=> item.ItemId).ToList();

            var items = await _client.GetItemsXmlByIds(itemIds);

            return items;
        }
    }
}
