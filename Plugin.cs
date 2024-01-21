using Exiled.API.Enums;
using Log = Exiled.API.Features.Log;
using ServerEvents = Exiled.Events.Handlers.Server;
using PlayerEvents = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;
using WarheadEvents = Exiled.Events.Handlers.Warhead;
using Handlers = Exiled.Events.Handlers;
using Features = Exiled.API.Features;
using Exiled.Events;
using PeutiPlugin;
using System;
using System.Runtime.InteropServices;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System.ComponentModel;
using Exiled.API.Features;

namespace PeutiPlugin
{
    public class BroadcastPlugin : Features.Plugin<Configs>
    {
        public EventHandlers EventHandlers { get; private set; }

        public override string Name { get; } = "프티(편의성플러그인)";
        public override string Prefix { get; } = "편의성플러그인";
        public override string Author { get; } = "@Peuti";
        public override Version Version { get; } = new Version(1, 0, 2);
        public override Version RequiredExiledVersion { get; } = new Version(8, 5, 0);

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public void LoadEvents()
        {
            MapEvents.AnnouncingDecontamination += EventHandlers.OnAnnouncingDecontamination;
            MapEvents.Decontaminating += EventHandlers.OnDecontaminating;
            MapEvents.AnnouncingNtfEntrance += EventHandlers.OnAnnouncingNtfEntrance;
            PlayerEvents.Dying += EventHandlers.OnPlayerDeath;
            Handlers.Scp079.InteractingTesla += EventHandlers.On079TeslaEvent;   
            ServerEvents.RoundEnded += EventHandlers.OnRoundEnded;
            Handlers.Scp096.AddingTarget += EventHandlers.On096AddTarget;
            ServerEvents.RespawningTeam += EventHandlers.OnTeamRespawn;
            MapEvents.AnnouncingScpTermination += EventHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Left += EventHandlers.OnScpLeave;
            WarheadEvents.Starting += EventHandlers.OnStarting;
            //PlayerEvents.Spawning -= EventHandlers.OnSpawning;
            WarheadEvents.Stopping += EventHandlers.OnStopping;
            Exiled.Events.Handlers.Player.Hurting += OnAttack;
            Exiled.Events.Handlers.Player.EscapingPocketDimension += OnEscaping;
            PlayerEvents.Dying += EventHandlers.OnPlayerDied;





        }

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;

            base.OnEnabled();

            EventHandlers = new EventHandlers(this);
            LoadEvents();   
            Log.Info("플러그인 활성화1");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            MapEvents.AnnouncingDecontamination -= EventHandlers.OnAnnouncingDecontamination;
            MapEvents.Decontaminating -= EventHandlers.OnDecontaminating;
            MapEvents.AnnouncingNtfEntrance -= EventHandlers.OnAnnouncingNtfEntrance;
            PlayerEvents.Dying -= EventHandlers.OnPlayerDeath;
            Handlers.Scp079.InteractingTesla -= EventHandlers.On079TeslaEvent;
            ServerEvents.RoundEnded -= EventHandlers.OnRoundEnded;
            Handlers.Scp096.AddingTarget -= EventHandlers.On096AddTarget;
            ServerEvents.RespawningTeam -= EventHandlers.OnTeamRespawn;
            MapEvents.AnnouncingScpTermination -= EventHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Left -= EventHandlers.OnScpLeave;
            //PlayerEvents.Spawning -= EventHandlers.OnSpawning;
            WarheadEvents.Starting -= EventHandlers.OnStarting;
            WarheadEvents.Stopping -= EventHandlers.OnStopping;
            Exiled.Events.Handlers.Player.Hurting -= OnAttack;
            Exiled.Events.Handlers.Player.EscapingPocketDimension -= OnEscaping;
            PlayerEvents.Dying -= EventHandlers.OnPlayerDied;



            EventHandlers = null;
        }

            public void OnEscaping(EscapingPocketDimensionEventArgs ev)
            {
                ev.Player.ShowHint(Config.EscapedHintText, Config.EscapedHintDuration);
            }

            public void OnAttack(HurtingEventArgs ev)
            {
                if (ev.Attacker != null && ev.Player != null)
                {
                    if (ev.Attacker.Role == RoleTypeId.Scp106)
                    {
                        ev.Player.ShowHint(Config.CaughtHintText.Replace("%attacker%", ev.Attacker.Nickname), Config.CaughtHintDuration);
                        ev.Player.EnableEffect(EffectType.Corroding);
                    }
                }
            }

        


        public override void OnReloaded()
        {

        }
    }
}
