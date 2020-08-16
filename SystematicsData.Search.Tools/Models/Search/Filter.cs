using System;

namespace SystematicsData.Search.Tools.Models.Search
{
    public class Filter
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public Filter()
        {
            Name = String.Empty;
            DisplayText = String.Empty;
        }
    }
}
