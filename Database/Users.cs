using System;
using System.ComponentModel.DataAnnotations;

namespace TomBot.Database
{
    public partial class Users
    {
        [Key]
        public long Id { get; set; }
        public string UserIdentification { get; set; }
        public string Username { get; set; }
    }
}