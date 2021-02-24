using System;
using System.ComponentModel.DataAnnotations;

namespace TomBot.Database
{
    public partial class TacbuxTotals
    {
        [Key]
        public long UserId { get; set; }
        public string TacbuxTotal { get; set; }
    }
}