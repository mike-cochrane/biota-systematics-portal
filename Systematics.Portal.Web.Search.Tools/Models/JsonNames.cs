using System;

//using System.Threading.Tasks;

namespace Systematics.Portal.Web.Search.Tools.Models
{
    public class Rootobject
    {
        public Responseheader responseHeader { get; set; }
        public Response response { get; set; }
    }

    public class Responseheader
    {
        public int status { get; set; }
        public int QTime { get; set; }
        public Params _params { get; set; }
    }

    public class Params
    {
        public string indent { get; set; }
        public string q { get; set; }
        public string wt { get; set; }
    }

    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public Doc[] docs { get; set; }
    }

    public class Doc
    {
        public string id { get; set; }
        public string dataProvider { get; set; }
        public string accessLevel { get; set; }
        public string documentType { get; set; }
        public DateTime modified { get; set; }
        public string nameId { get; set; }
        public string fullName { get; set; }
        public string fullNameFormatted { get; set; }
        public string partName { get; set; }
        public string governingCode { get; set; }
        public string[] governingCode_ss { get; set; }
        public string taxonRank { get; set; }
        public string parentName { get; set; }
        public string parentNameId { get; set; }
        public string currentName { get; set; }
        public string currentNameId { get; set; }
        public string kingdom { get; set; }
        public string[] kingdom_ss { get; set; }
        public string phylum { get; set; }
        public string[] phylum_ss { get; set; }
        public string _class { get; set; }
        public string[] class_ss { get; set; }
        public string order { get; set; }
        public string[] order_ss { get; set; }
        public string family { get; set; }
        public string[] family_ss { get; set; }
        public string genus { get; set; }
        public string[] genus_ss { get; set; }
        public long _version_ { get; set; }
        public string authors { get; set; }
        public string publicationYear { get; set; }
    }
}