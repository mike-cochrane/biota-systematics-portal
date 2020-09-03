using System;

namespace SystematicsPortal.Web.Views.Documents.Components.ReferenceHyperlink
{
    public class ReferenceHyperlinkViewComponentSettings
    {
        public ReferenceHyperlinkViewComponentSettings(Uri referenceHyperlinkBase)
        {
            ReferenceHyperlinkBase = referenceHyperlinkBase;
        }

        public Uri ReferenceHyperlinkBase { get; }
    }
}
