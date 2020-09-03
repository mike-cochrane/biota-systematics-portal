using System;

namespace SystematicsPortal.Web.Views.Documents.Components.NameHyperlink
{
    public class NameHyperlinkViewComponentSettings
    {
        public NameHyperlinkViewComponentSettings(Uri nameHyperlinkBase)
        {
            NameHyperlinkBase = nameHyperlinkBase;
        }

        public Uri NameHyperlinkBase { get; }
    }
}
