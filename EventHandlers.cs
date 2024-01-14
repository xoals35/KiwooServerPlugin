using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
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
using Exiled.Events.EventArgs.Scp096;
using DamageTypes = Exiled.API.Enums.DamageType;
using Features = Exiled.API.Features;
using Round = Exiled.API.Features.Round;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Scp079;
using Exiled.API.Interfaces;
using static Exiled.API.Features.Player;
using CustomAttackerHandler = Exiled.API.Features.DamageHandlers.AttackerDamageHandler;
using DamageHandlerBase = PlayerStatsSystem.DamageHandlerBase;
using PluginAPI.Enums;
using PluginAPI.Events;
using Exiled.API.Extensions;
using static MapGeneration.ImageGenerator;
using UnityEngine;
using System.Runtime.Remoting.Messaging;
using Utf8Json.Formatters;
using Exiled.API.Features.Items;
using DamageType = Exiled.API.Enums.DamageType;
using BaseFirearmHandler = PlayerStatsSystem.FirearmDamageHandler;
using BaseHandler = PlayerStatsSystem.DamageHandlerBase;
using BaseScpDamageHandler = PlayerStatsSystem.ScpDamageHandler;
using System.ComponentModel;
using static UnityEngine.GraphicsBuffer;
using System.Diagnostics.Eventing.Reader;
using Exiled.API.Features.Spawn;
using PlayerRoles.PlayableScps.Scp106;


namespace PeutiPlugin
{

    public class EventHandlers : IDisposable
    {


        private BroadcastPlugin _pluginInstance;
        public EventHandlers(BroadcastPlugin pluginInstance)
        {
            _pluginInstance = pluginInstance;
        }
        public DateTime lastTeslaEvent;
        public Dictionary<Features.Player, DateTime> LastCommand { get; set; } = new Dictionary<Features.Player, DateTime>();
        private static Dictionary<string, DateTime> PreauthTime { get; set; } = new Dictionary<string, DateTime>();
        public static Dictionary<Features.Player, DateTime> LastRespawn { get; set; } = new Dictionary<Features.Player, DateTime>();
        private static Dictionary<Features.Player, string> Cuffed { get; set; } = new Dictionary<Features.Player, string>();





        public int ChaosRespawnCount { get; set; }

        public int MtfRespawnCount { get; set; }

        public DateTime LastChaosRespawn { get; set; }

        public DateTime LastMtfRespawn { get; set; }


        internal void OnRoundStartin경
        //{
        //    if (ev.Player == null) return;


        //    if (ev.Player.Role == RoleTypeId.Scp3114)
        //    {
        //        ev.Player.MaxHealth = 2000;
                

        //    }
        //    if (ev.Player.Role == RoleTypeId.Scp096)
        //    {
        //        ev.Player.MaxHealth = 2900;
        //    }
        //    if (ev.Player.Role == RoleTypeId.Scp106)
        //     {
        //         ev.Player.MaxHealth = 2500;
                
        //     }
        //}

       
    



        internal void OnRoundEnding(RoundEndedEventArgs ev)
        {


            Map.Broadcast(10, "<color=green>라운드가 종료되었습니다.</color>");
        }


        public void OnAnnouncingScpTermination(AnnouncingScpTerminationEventArgs ev)
        {
            if (ev.Player == null) return;
            if (ev.DamageHandler.Type == DamageTypes.Crushed || ev.DamageHandler.Type == DamageTypes.Falldown || ev.DamageHandler.Type == DamageTypes.Unknown && ev.DamageHandler.Damage >= 50000 || ev.DamageHandler.Type == DamageTypes.Unknown && ev.DamageHandler.Damage >= 50000 || ev.DamageHandler.Type == DamageTypes.Tesla || ev.DamageHandler.Type == DamageTypes.Warhead || (ev.DamageHandler.Type == DamageTypes.Explosion && ev.DamageHandler.IsSuicide))
            {

            }

            else if ((ev.DamageHandler.Type == DamageTypes.Unknown && ev.DamageHandler.Damage == -1f) && _pluginInstance.Config.QuitEqualsSuicide)
            {

            }

            if (!ev.DamageHandler.IsSuicide)
                {

                    if (ev.Attacker == null)
                    {
                        if (_pluginInstance.Config.ScpSuicideMessage.Show)
                        {
                            var message = _pluginInstance.Config.ScpSuicideMessage.Content;
                            message = message.Replace("%scpname%", ev.Player.Role.Type.ToString()).Replace("%reason%", ev.DamageHandler.Type.ToString());
                            Map.Broadcast(_pluginInstance.Config.ScpSuicideMessage.Duration, message, _pluginInstance.Config.ScpSuicideMessage.Type);
                        }
                    }
                    else
                    {
                        if (_pluginInstance.Config.ScpDeathMessage.Show)
                        {
                            var message = _pluginInstance.Config.ScpDeathMessage.Content;
                            message = message.Replace("%scpname%", ev.Player.Role.Type.ToString()).Replace("%killername%", ev.Attacker.Nickname).Replace("%reason%", ev.DamageHandler.Type.ToString());
                            Map.Broadcast(_pluginInstance.Config.ScpDeathMessage.Duration, message, _pluginInstance.Config.ScpDeathMessage.Type);
                        }
                    }

                }
            }

        public void OnStopping(StoppingEventArgs ev)
        {
            Map.Broadcast(8, $"<color=red>알파탄두 핵폭탄</color>이 취소되었습니다. \n취소한 사람: {ev.Player.Nickname}/{ev.Player.Role.Name}");
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Warhead.OnStarting(StartingEventArgs)"/>
        public void OnStarting(StartingEventArgs ev)
        {
            Map.Broadcast(8, $"<color=red>알파탄두 핵폭탄</color>이 실행되었습니다. \n실행한 사람: {ev.Player.Nickname}/{ev.Player.Role.Name}");
        }


       

        public void Dispose()
            {
                _pluginInstance = null;
            }
        }
}
