using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwinSunsBot.Net
{
    class DonationAd
    {
        public static void Run()
        {
            Thread.Sleep(30000);
            var channel = Program._client.GetGuild(AdVariables.guild).GetTextChannel(AdVariables.adminchannel);
            if (AdVariables.enabled == false)
            {
                channel.SendMessageAsync("Twin Suns Bot start up.\nDonation ad enabled setting false. Disabling.");
                return;
            } else
            {
                channel.SendMessageAsync($"Twin Suns Bot start up.\nDonation ad enabled setting true. Enabling. Message:\n\n{AdVariables.message}");
            }
            var thread = new Thread(Ad)
            {
                IsBackground = false
            };
            thread.Start();
        }

        static async void Ad()
           
        {
            
            var channel= Program._client.GetGuild(AdVariables.guild).GetTextChannel(AdVariables.adchannel); //GetGuild(AdVariables.guild).GetTextChannel(AdVariables.adchannel);
            for (; ; )
            {
                Program.Log("Sending ad to channel");
                await channel.SendMessageAsync(AdVariables.message);
                Thread.Sleep(AdVariables.adinterval);
            }
        }
    }
}
