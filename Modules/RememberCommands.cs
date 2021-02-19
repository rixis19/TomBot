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
    public class RememberCommands : ModuleBase
    {
        //remembers something from the chat log
        [Command("remember")]
        public async Task RememberCommand()
        {
            
        }
    }
}