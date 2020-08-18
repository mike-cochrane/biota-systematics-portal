using System;

namespace SystematicsData.Search.Models.Search
{
    public abstract class Filter
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string FilterType { get; }

        public Filter()
        {
            Name = String.Empty;
            DisplayText = String.Empty;
        }

        public Filter(string type)
        {
            Name = String.Empty;
            DisplayText = String.Empty;
            FilterType = type;
        }
    }
}
