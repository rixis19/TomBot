using System;
using System.ComponentModel.DataAnnotations;

namespace TomBot.Database
{
    public partial class RememberThis
    {
        [Key]
        public long AnswerId { get; set; }
        public string AnswerText { get; set; }
        public string AnswerAuthor { get; set; }
    }
}