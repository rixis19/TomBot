using System;
using System.ComponentModel.DataAnnotations;

namespace TomBot.Database
{
    public partial class TomQuotes
    {
        [Key]
        public long AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}