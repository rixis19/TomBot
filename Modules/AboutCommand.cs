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
    public class AboutCommand : ModuleBase
    {
        [Command("about")]
        public async Task About()
        {
            var embed = new EmbedBuilder();

            embed.Title = "About This Bot";
            embed.WithAuthor(Context.Client.CurrentUser);
            embed.Description = "Wondering what commands you can use? Here's a list! Use \";help *command here*\" to get specific information on the usage of any particular command.";
            embed.AddField("Memory Commands","`rememberthis` `recall` `tomquote`", true);
            embed.AddField("Descision Commands","`8ball`", true);

            await ReplyAsync(null, false, embed.Build());
        }
    }
}