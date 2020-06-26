namespace Systematics.Portal.Model.Models.Annotations
{
    public class Term
    {

        //The name of the vocabulary to which this term belongs
        public string VocabularyId { get; set; }
        public string VocabularyUseId { get; set; }
        public string TermId { get; set; }

        //The actual term
        public string Label { get; set; }

        public string TermUseId { get; set; }
        public string AddedBy { get; set; }
        public int? DisplayOrder { get; set; }


        public Term()
        {
            Label = string.Empty;
            TermUseId = string.Empty;
            AddedBy = string.Empty;
        }
    }
}
