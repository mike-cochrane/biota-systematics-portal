using System;

namespace SystematicsPortal.Web.Models
{
    public class EditableContentViewModel : ViewModelBase
    {
        public string Section { get; set; }
        public string ContentToRender { get; set; }

        public EditableContentViewModel() : base()
        {
            Section = String.Empty;
            ContentToRender = "Sorry, but this content is not available right now.";
        }
    }
}