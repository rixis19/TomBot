  
using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TomBot.Services
{
    public class GuildJoinedService
    {
        private readonly DiscordSocketClient _client;
        private readonly IServiceProvider _services;

        public GuildJoinedService(IServiceProvider services)
        {
            _client = services.GetRequiredService<DiscordSocketClient>();
            _services = services;

            _client.JoinedGuild += OnJoinedGuildAsync;
        }

        private Task OnJoinedGuildAsync(SocketGuild guild)
        {
            return guild.DefaultChannel.SendMessageAsync("HULLOOOOOOOOO, thanks for the invite, ploob. Use `;help` to see the list of commands.");
        }
    }
}