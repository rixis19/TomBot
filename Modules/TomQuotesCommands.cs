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
    public class TomQuotesCommands : ModuleBase
    {
        private readonly TomBotEntities _db;
        private readonly IConfiguration _config;
        private Random rng = new Random();

        public TomQuotesCommands(IServiceProvider services)
        {
            _db = services.GetRequiredService<TomBotEntities>();
            _config = services.GetRequiredService<IConfiguration>();
        }

        //tomquote recall
        [Command("tomquote")]
        public async Task TomQuoteCommand([Remainder]string args = null)
        {
            var sb = new StringBuilder();
            var embed = new EmbedBuilder();

            var replies = await _db.TomQuotes.ToListAsync();
            var answer = replies[new Random().Next(replies.Count)];
            
            embed.Title = $"It's like rixis19 always says...";
            sb.AppendLine($"...\"**{answer.AnswerText}**\".");

            embed.WithColor(0, 0, 255);
            embed.Description = sb.ToString();

            await ReplyAsync(null, false, embed.Build());
        }
    }
}