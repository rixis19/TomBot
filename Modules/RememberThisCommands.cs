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
    public class RememberThisCommands : ModuleBase
    {
        private readonly TomBotEntities _db;
        private readonly IConfiguration _config;
        private Random rng = new Random();

        public RememberThisCommands(IServiceProvider services)
        {
            _db = services.GetRequiredService<TomBotEntities>();
            _config = services.GetRequiredService<IConfiguration>();
        }

        [Command("rememberthis")]
        public async Task AddResponse([Remainder]string message)
        {            
            var sb = new StringBuilder();
            
            await _db.AddAsync(new RememberThis
                {
                    AnswerText  = message,
                    AnswerAuthor = Context.User.Username.ToString()                     
                }
            );

            await _db.SaveChangesAsync();   
            sb.AppendLine("I'll try to remember that");
            await ReplyAsync(sb.ToString());
        }

        [Command("recall")]
        public async Task GetResponse([Remainder]string args = null)
        {
            var sb = new StringBuilder();
            var embed = new EmbedBuilder();

            var replies = await _db.RememberThis.ToListAsync();
            var answer = replies[new Random().Next(replies.Count)];

            
            embed.Title = $"Remember when **{answer.AnswerAuthor}** said...";
            sb.AppendLine($"...\"**{answer.AnswerText}**\".");

            embed.WithColor(0, 255, 0);
            embed.Description = sb.ToString();

            await ReplyAsync(null, false, embed.Build());
        }
    }
}