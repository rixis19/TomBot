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
    // for commands to be available, and have the Context passed to them, we must inherit ModuleBase
    public class HulloCommand : ModuleBase
    {
        [Command("hullo")]
        public async Task Hullo()
        {
            var sb = new StringBuilder();
            var user = Context.User;
            sb.AppendLine($"HULLLLLLLLOOOOOOOOOOOOOOOO {user.Username}");
            await ReplyAsync(sb.ToString());
        }       
    }
}