﻿using Annotations.Messaging.Contracts.Items;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystematicsPortal.Models.Interfaces;

namespace SystematicsPortal.Data.Harvester.Consumers
{
    internal class ItemUpdatedConsumer : IConsumer<IItemUpdated>
    {
        private readonly IHarvesterStrategies _harvesterStrategies;

        public ItemUpdatedConsumer(IHarvesterStrategies harvesterStrategies)
        {
            _harvesterStrategies = harvesterStrategies;
        }

        public async Task Consume(ConsumeContext<IItemUpdated> context)
        {
            await Task.Run(() => Console.WriteLine("Item Updated: " + context.Message.ItemId + " - " + context.Message.ResourceId));

            // TODO: Ask Mike if we can get the itemtypeid
            var selector = $"{context.Message.ResourceId}|{context.Message.ItemTypeId}";

            var strategy = _harvesterStrategies.GetStrategies()[selector];

            var results = strategy.ApplyStrategyAsync(context.Message.ResourceId, context.Message.ItemTypeId, context.Message.ItemId);
        }
    }
}

namespace Annotations.Messaging.Contracts.Items
{
    public interface IItemUpdated
    {
        public string ItemId { get; set; }
        public string ResourceId { get; set; }
        public string ItemTypeId { get; set; }
    }
}
