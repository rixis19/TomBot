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
    public class AboutCommand : ModuleBase
    {
        [Command("about")]
        public async Task About()
        {
            var embed = new EmbedBuilder();

            embed.Title = "About This Bot";
            embed.WithAuthor(Context.Client.CurrentUser);
            embed.Description = "Welcome to TomBot! This bot was developed by rixis19, with the purpose of being a " +
                "joke bot that would print out things rixis19(Tom) would say in real life. Since then, " +
                "it's become a little more defined. This bot can now save quotations of its users and " +
                "recall them, and play decision games. It still has a lot of work to be done, but it is " +
                "coming along very nicely. All I ask is you have fun with it and use it wisely!";
            embed.AddField("Contact","@rixis19#9677, [TomBot's Github](https://github.com/rixis19/TomBot)");
            await ReplyAsync(null, false, embed.Build());
        }
    }
}