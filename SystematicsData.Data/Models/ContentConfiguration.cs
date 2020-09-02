﻿using System;

namespace SystematicsData.Data.Models
{
    public class ContentConfiguration
    {
        public Guid ContentConfigurationId { get; set; }

        public string Page { get; set; }

        public string Section { get; set; }

        public string SectionTitle { get; set; }

        public Guid? ExternalId { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
