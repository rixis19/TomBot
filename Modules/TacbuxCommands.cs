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
        [Command("addTacbux")]
        public async Task AddTacbux()
        {

        }

        [Command("checkServerOwner")]
        public async Task checkServerOwner()
        {
            var sb = new StringBuilder();
            var admin = Context.Guild.OwnerId.ToString();
            var user = Context.User.ToString();

            /*if(user.Equals(admin))
            {
                sb.AppendLine($"User: {user}, Admin:{admin}");
                sb.AppendLine($"true");
            }
            else
            {
                sb.AppendLine($"User: {user}, Admin:{admin}");
                sb.AppendLine("false");
            }*/
            
            //sb.AppendLine($"{admin.ToString()}");

            await ReplyAsync(sb.ToString());
        }
    }
}