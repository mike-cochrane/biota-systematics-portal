using System;

namespace SystematicsData.Search.Models.Search
{
    public class Filter
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string FilterType { get; set; }

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
