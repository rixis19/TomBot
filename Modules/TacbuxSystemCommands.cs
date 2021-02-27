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
    public class TacbuxSystemCommands : ModuleBase
    {
        private readonly TomBotEntities _db;
        private readonly IConfiguration _config;
        private Random rng = new Random();

        public TacbuxSystemCommands(IServiceProvider services)
        {
            _db = services.GetRequiredService<TomBotEntities>();
            _config = services.GetRequiredService<IConfiguration>();
        }

        [Command("addTacbux")]
        public async Task AddTacbux(string user, int amount)
        {
            var embed = new EmbedBuilder();
            var userList = await _db.TacbuxSystem.ToListAsync();
            var userToAdjust = userList.Where(a => a.User == user).FirstOrDefault();

            if(Context.User.Equals(await Context.Guild.GetOwnerAsync()))
            {
                if (userToAdjust != null)
                {
                    embed.Title = "Tacbux";
                    embed.WithAuthor(Context.Client.CurrentUser);
                    embed.Description = $"{amount} tacbux given to {user}, amounting to {userToAdjust.TacbuxTotal + (long)amount}.";
                    userToAdjust.TacbuxTotal = userToAdjust.TacbuxTotal + (long)amount;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    await _db.AddAsync(new TacbuxSystem
                    {
                        User  = user,
                        TacbuxTotal = (long)amount                     
                    }
                    );
                    embed.Title = "Tacbux";
                    embed.WithAuthor(Context.Client.CurrentUser);
                    embed.Description = $"User {user} created in database. {amount} tacbux given to {user}, amounting to {(long)amount}.";
                    await _db.SaveChangesAsync();
                }
            }
            else
            {
                embed.Title = "Tacbux";
                embed.WithAuthor(Context.Client.CurrentUser);
                embed.Description = $"{Context.User.Username.ToString()} does not have permission level required to use this command.";
            }
            await ReplyAsync(null, false, embed.Build());
        }

        /*[Command("topten")]
        public async Task TopTen([Remainder]string args = null)
        {
            var userList = await _db.TacbuxSystem.ToListAsync();
            var userWallet = userList.Where(a => a.User == Context.User.ToString()).FirstOrDefault();
            var embed = new EmbedBuilder();

            if(args == null)
            {
                embed.Title = "Current Top Ten";
                embed.Description = $"{Context.User.Username.ToString()}, you have {userWallet.TacbuxTotal} tacbux.";
                await ReplyAsync(null, false, embed.Build());
            }
            else if(args.Equals("alltime"))
            {

            }
        }*/

        [Command("myWallet")]
        public async Task myWallet()
        {
            var userList = await _db.TacbuxSystem.ToListAsync();
            var userWallet = userList.Where(a => a.User == Context.User.ToString()).FirstOrDefault();
            var embed = new EmbedBuilder();

            embed.Title = "Your Wallet";
            embed.WithAuthor(Context.User.Username);
            embed.Description = $"{Context.User.Username.ToString()}, you have {userWallet.TacbuxTotal} tacbux.";
            await ReplyAsync(null, false, embed.Build());
        }

        [Command("subtractTacbux")]
        public async Task SubtractTacbux(string user, int amount)
        {
            var embed = new EmbedBuilder();
            var userList = await _db.TacbuxSystem.ToListAsync();
            var userToAdjust = userList.Where(a => a.User == user).FirstOrDefault();

            if(Context.User.Equals(await Context.Guild.GetOwnerAsync()))
            {
                if (userToAdjust != null)
                {
                    embed.Title = "Tacbux";
                    embed.WithAuthor(Context.Client.CurrentUser);
                    embed.Description = $"{amount} tacbux subtracted from {user}'s total, amounting to {userToAdjust.TacbuxTotal - (long)amount}.";
                    userToAdjust.TacbuxTotal = userToAdjust.TacbuxTotal - (long)amount;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    embed.Title = "Tacbux";
                    embed.WithAuthor(Context.Client.CurrentUser);
                    embed.Description = $"This user does not exist in the database, nor can their total be negative.";
                }
            }
            else
            {
                embed.Title = "Tacbux";
                embed.WithAuthor(Context.Client.CurrentUser);
                embed.Description = $"{Context.User.Username.ToString()} does not have permission level required to use this command.";
            }
            await ReplyAsync(null, false, embed.Build());
        }

        [Command("checkServerOwner")]
        public async Task ServerOwner()
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