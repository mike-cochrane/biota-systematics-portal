namespace SystematicsPortal.Web.Search.Tools.Models.Search
{
    public class SelectedRange
    {
        public string GroupName { get; set; }
        public string FacetName { get; set; }
        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }
        public string Label
        {
            get
            {
                if (FacetName.ToLower().Contains("date"))
                {
                    return FacetName + ": " + MinimumValue.ToString("####-##-##") + " to " + MaximumValue.ToString("####-##-##");
                }
                else
                {
                    return FacetName + ": " + MinimumValue.ToString() + " - " + MaximumValue.ToString();
                }
            }
        }

        public SelectedRange()
        {
            GroupName = string.Empty;
            FacetName = string.Empty;
            MinimumValue = int.MaxValue;
            MaximumValue = int.MaxValue;
        }
    }
}
