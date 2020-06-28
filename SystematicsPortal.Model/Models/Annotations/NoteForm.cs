using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    public class NoteForm
    {
        public string NoteFormId { get; set; }
        public string NoteStateId { get; set; }
        public string NoteStateTitle { get; set; }
        // public XElement Content { get; set; }
        public string SecurityId { get; set; }
        public int? SecurityLevel { get; set; }
        public string SecurityTitle { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<Image> Images { get; set; }
        // List of comments that we get from client app and they will saved as an xml field on DB
        [XmlArray("Comments")]
        [XmlArrayItem("Comment")]
        public List<Comment> Comments { get; set; }

        public NoteForm()
        {
            Images = new List<Image>();
            Comments = new List<Comment>();
        }
    }
}