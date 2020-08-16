using System;

namespace SystematicsData.Search.Tools.Models.Search
{
    public class Range : Filter
    {
        public const int NUMBER_SPARKLINES = 95;

        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
        public string Type { get; set; }
        public bool IncludeNulls { get; set; }
        public string SparklineData { get; set; }

        public Range() : base()
        {
            MinimumValue = 0;
            MaximumValue = 0;
            Type = "numeric";
            IncludeNulls = false;
            SparklineData = String.Empty;
        }
    }
}
