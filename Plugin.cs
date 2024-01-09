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

namespace PeutiPlugin
{
    public class BroadcastPlugin : Features.Plugin<Configs>
    {
        public EventHandlers EventHandlers { get; private set; }

        public override string Name { get; } = "프티(편의성플러그인)";
        public override string Prefix { get; } = "편의성플러그인";
        public override string Author { get; } = "@Peuti";
        public override Version Version { get; } = new Version(1, 0, 1);
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
            PlayerEvents.Handcuffing += EventHandlers.OnPlayerHandcuff;
            PlayerEvents.RemovingHandcuffs += EventHandlers.OnPlayerUnhandCuff;
            MapEvents.AnnouncingScpTermination += EventHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Left += EventHandlers.OnScpLeave;
            PlayerEvents.Spawning += EventHandlers.OnSpawning;
            WarheadEvents.Starting += EventHandlers.OnStarting;
            WarheadEvents.Stopping += EventHandlers.OnStopping;
           
            


        }

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;

            base.OnEnabled();

            EventHandlers = new EventHandlers(this);
            LoadEvents();   
            Log.Info("플러그인 활성화");
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
            PlayerEvents.Handcuffing -= EventHandlers.OnPlayerHandcuff;
            PlayerEvents.RemovingHandcuffs -= EventHandlers.OnPlayerUnhandCuff;
            MapEvents.AnnouncingScpTermination -= EventHandlers.OnAnnouncingScpTermination;
            PlayerEvents.Left -= EventHandlers.OnScpLeave;
            PlayerEvents.Spawning -= EventHandlers.OnSpawning;
            WarheadEvents.Starting -= EventHandlers.OnStarting;
            WarheadEvents.Stopping -= EventHandlers.OnStopping;




            EventHandlers = null;
        }

        public override void OnReloaded()
        {

        }
    }
}
