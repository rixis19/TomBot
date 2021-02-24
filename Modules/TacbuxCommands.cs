using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using TomBot.Database;
using Microsoft.Extensions.DependencyInjection;

namespace TomBot.Modules
{
    public class TacbuxCommands : ModuleBase
    {
        private readonly TomBotEntities _db;
        private readonly IConfiguration _config;
        private Random rng = new Random();

        [Command("addTacbux")]
        public async Task AddTacbux(string user, int amount)
        {
            if(Context.User.Equals(await Context.Guild.GetOwnerAsync()))
            {
                
            }
            else
            {

            }
            await ReplyAsync();
        }

        [Command("checkServerOwner")]
        public async Task checkServerOwner()
        {
            var sb = new StringBuilder();
            
            if(Context.User.Equals(await Context.Guild.GetOwnerAsync()))
                sb.AppendLine("true");
            else
                sb.AppendLine("false");

            await ReplyAsync(sb.ToString());
        }
    }
}