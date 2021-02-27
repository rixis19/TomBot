using System;
using System.ComponentModel.DataAnnotations;

namespace TomBot.Database
{
    public partial class TacbuxSystem
    {
        [Key]
        public long ListId { get; set; }
        public string User { get; set; }
        public string ServerName { get; set; }
        public long TacbuxTotal { get; set; }
    }
}