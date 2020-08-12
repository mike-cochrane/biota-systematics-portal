using System.Xml.Serialization;

namespace SystematicsData.Models.Entities.Annotations
{

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Comment
    {

        private string _addedByField;

        private string _textField;

        private string _addedDateField;

        /// <remarks/>
        [XmlElement(ElementName = "AddedBy")]
        public string Author
        {
            get => this._addedByField;
            set => this._addedByField = value;
        }

        /// <remarks/>
        public string Text
        {
            get => this._textField;
            set => this._textField = value;
        }

        /// <remarks/>
        [XmlElement(ElementName = "AddedDate")]
        public string Date
        {
            get => this._addedDateField;
            set => this._addedDateField = value;
        }
    }

}
