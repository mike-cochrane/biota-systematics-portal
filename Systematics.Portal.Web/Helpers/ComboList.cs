using System.Collections.Generic;

namespace Systematics.Portal.Web.Helpers
{
    public class ComboList
    {
        public List<ComboItem> Items { get; private set; }

        public ComboList()
        {
            Items = new List<ComboItem>();
        }

        public void AddItem(string key, string displayText)
        {
            ComboItem item = new ComboItem(key, displayText);
            Items.Add(item);
        }
    }

    public class ComboItem
    {
        public string Key { get; private set; }
        public string DisplayText { get; private set; }

        public ComboItem(string key, string displayText)
        {
            Key = key;
            DisplayText = displayText;
        }
    }
}