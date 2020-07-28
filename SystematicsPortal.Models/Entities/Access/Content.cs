﻿using System.ComponentModel;

namespace SystematicsPortal.Models.Entities.Access
{
    public class Content
    {
        [DisplayName("Lede")]
        public string Lede { get; set; }
        [DisplayName("Citation Title")]
        public string CitationTitle { get; set; }
        [DisplayName("Section Title")]
        public string SectionTitle { get; set; }
        [DisplayName("Text")]
        public string Text { get; set; }
    }
}
