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
    public class HelpCommands : ModuleBase
    {
        [Command("help")]
        public async Task Help()
        {
            var embed = new EmbedBuilder();

            embed.Title = "List of Commands";
            embed.WithAuthor(Context.Client.CurrentUser);
            embed.Description = "Wondering what commands you can use? Here's a list! Use \";help *command here*\" to get specific information on the usage of any particular command.";
            embed.AddField("Memory Commands","`rememberthis` `recall` `tomquote`", true);
            embed.AddField("Descision Commands","`8ball`", true);

            await ReplyAsync(null, false, embed.Build());
        }

        [Command("help")]
        public async Task HelpSpecific([Remainder]string command)
        {
            var embed = new EmbedBuilder();
            embed.WithAuthor(Context.Client.CurrentUser);

            if(command.Equals("rememberthis"))
            {
                embed.Title = "Remember This Quote (;rememberthis)";
                embed.Description = "Remember this takes in a phrase or sentence to be stored in memory, and then recalled with `;recall` (See `;help recall` for more information).";
                embed.AddField("`;rememberthis *phrase*`","'*phrase*' is stored into a database to be recalled later, the acknowledgement message and the origin command will be deleted after five seconds.");
            }
            else if(command.Equals("about"))
            {
                embed.Title = "About This Bot (;about)";
                embed.Description = "Prints out the history and purpose of this Discord bot.";
                embed.AddField("`;about`","Provides aformentioned information.");
            }
            else if(command.Equals("recall"))
            {
                embed.Title = "Recall a Quote (;recall)";
                embed.Description = "Recall prints out a phrase or sentence that has been stored in memory via `;rememberthis` (See `;help rememberthis` for more information).";
                embed.AddField("`;recall`","A phrase that has been stored into memory is recalled, it is randomly selected.");
            }
            else if(command.Equals("tomquote"))
            {
                embed.Title = "Say something Tom would say (;tomquote)";
                embed.Description = "Tom quote prints out a command that has been stored in memory.";
                embed.AddField("`;tomquote`","A tom quote is randomly selected from memory and printed out.");
            }
            else if(command.Equals("8ball"))
            {
                embed.Title = "Ask the magic 8-ball for a answer (;8ball)";
            }
            else
            {
                embed.Description = "Invalid command inputted, please refer to Help main for a list of commands.";
            }

            await ReplyAsync(null, false, embed.Build());
        }
    }
}