using System;
using System.Collections.Generic;

namespace FindWorker.Entity.Models
{
    public partial class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public int? LanguageLevel { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedUser { get; set; }


        public int? UserId { get; set; }
        public User user { get; set; }
    }
}
