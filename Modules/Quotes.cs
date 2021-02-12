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

namespace TomBot.Modules
{
    public class Quotes : ModuleBase
    {
        [Command("hullo")]
        public async Task HulloCommand()
        {
            var sb = new StringBuilder();
            var user = Context.User;
            sb.AppendLine($"HULLLLLLLLOOOOOOOOOOOOOOOO -> {user.Username}");
            await ReplyAsync(sb.ToString());
        }

        //tomquote recall
        [Command("tomquote")]
        public async Task TomQuoteCommand()
        {
            
        }

        //remembers something from the chat log
        [Command("remember")]
        public async Task RememberCommand()
        {
            
        }

        //recalls something from rememberthis log
        [Command("recall")]
        public async Task RecallCommand()
        {
            
        }

        //Remembers a specific quote fed into the bot
        [Command("rememberthis")]
        public async Task RememberThisCommand()
        {
            
        }
    }
}