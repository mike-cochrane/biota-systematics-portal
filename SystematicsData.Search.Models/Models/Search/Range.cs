using System;

namespace SystematicsData.Search.Models.Search
{
    public class Range : Filter
    {
        public const int NUMBER_SPARKLINES = 95;

        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
        public string Type { get; set; }
        public bool IncludeNulls { get; set; }
        public string SparkLineData { get; set; }

        public Range() : base("Range")
        {
            MinimumValue = 0;
            MaximumValue = 0;
            Type = "numeric";
            IncludeNulls = false;
            SparkLineData = String.Empty;
        }
    }
}
