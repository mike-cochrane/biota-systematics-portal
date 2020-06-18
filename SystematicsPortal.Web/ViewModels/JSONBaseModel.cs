using System.Collections.Generic;

namespace SystematicsPortal.Web.ViewModels
{
    public class JSONBaseModel
    {
        public string Information { get; set; }
        public string Error { get; set; }
    }

    public class JSONRequestConfirmationModel : JSONBaseModel
    {
        public string Request { get; set; }
    }

    public class JSONSpecimenAddedToSetModel : JSONBaseModel
    {
        public List<SetSummary> Sets { get; set; }
    }

    public class SetSummary
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }

    public class JSONUpdatedProfileModel : JSONBaseModel
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool EmailUpdated { get; set; }
    }

    public class JSONToggleSpecimenSelectionModel : JSONBaseModel
    {
        public bool OneOrMoreSelected { get; set; }
    }
}
