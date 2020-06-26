using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Systematics.Portal.Model.Models.Annotations
{
    [XmlRoot("noteStates")]
    public class NoteStates
    {
        [XmlElement("noteState")]
        public List<NoteState> States { get; set; }
    }
}
