using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.EventArgs.Warhead;
using CustomPlayerEffects;
using Footprinting;
using PlayerStatsSystem;
using Exiled.Events;
using PlayerRoles;
using Respawning;
using PluginAPI.Events;
using System.Runtime.Remoting.Messaging;
using CommandSystem.Commands.Console;
using System.Diagnostics.Eventing.Reader;

namespace PeutiPlugin
{

    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]

    internal class scpchat : ICommand
    {
        public string Command { get; } = "scpchat";
        public string[] Aliases { get; } = new[] { "c", "ㅊ" };
        public string Description { get; } = "scpchat 입니다.";
        public bool Execute(ArraySegment<string> Arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            



            
            string content = $"<color=red>[SCPCHAT]</color>{player.Nickname}({player.Role.Name})\n 메세지 내용: ";

            for (int i = Arguments.Offset; i < Arguments.Count + Arguments.Offset; i++)
            {
                content += Arguments.Array[i] + " ";
            }
            response = null;

            if (player.Role.Team != Team.SCPs)
            {
                response = "당신은 SCP진영이 아닙니다.(플라밍고 제외)";
                return true;
            }

            foreach (var targetPlayer in Player.List)
            {
                if (targetPlayer.Role.Team == Team.SCPs)
                {
                    targetPlayer.Broadcast(5, content);
                    Log.Info($"{player.UserId}'s message : {content}");
                    return true;
                }
                
               
            }
            






            response = null;
            return false;
        }
       
            
        }




    }

        
   


