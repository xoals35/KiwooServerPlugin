using Exiled.API.Enums;
using Log = Exiled.API.Features.Log;
using ServerEvents = Exiled.Events.Handlers.Server;
using PlayerEvents = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;
using WarheadEvents = Exiled.Events.Handlers.Warhead;
using Features = Exiled.API.Features;
using Exiled.Events;
using PeutiPlugin;

namespace PeutiPlugin
{
    public class BroadcastPlugin : Features.Plugin<Configs>
    {
        public EventHandlers EventHandlers { get; private set; }

        public override string Name { get; } = "PeutiBroadcastPlugin";
        public override string Prefix { get; } = "PeutiBroadcastPlugin";
        public override string Author { get; } = "Peuti";

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public void LoadEvents()
        {
            ServerEvents.RoundStarted += EventHandlers.OnRoundStarting;
            MapEvents.AnnouncingDecontamination += EventHandlers.OnAnnouncingDecontamination;
            MapEvents.Decontaminating += EventHandlers.OnDecontaminating;
            MapEvents.AnnouncingNtfEntrance += EventHandlers.OnAnnouncingNtfEntrance;
           
        }

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;

            base.OnEnabled();

            EventHandlers = new EventHandlers(this);
            LoadEvents();
            Log.Info("브로드캐스트 플러그인 활성화");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            ServerEvents.RoundStarted -= EventHandlers.OnRoundStarting;
            MapEvents.AnnouncingDecontamination -= EventHandlers.OnAnnouncingDecontamination;
            MapEvents.Decontaminating -= EventHandlers.OnDecontaminating;
            MapEvents.AnnouncingNtfEntrance -= EventHandlers.OnAnnouncingNtfEntrance;
            
            EventHandlers = null;
        }

        public override void OnReloaded()
        {

        }
    }
}