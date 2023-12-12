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
using Exiled.Events;
using PlayerRoles;
using Respawning;
using Exiled.Events.EventArgs.Scp096;

using Exiled.API.Features.DamageHandlers;
using Exiled.API.Features.Roles;

using Exiled.API.Interfaces;

using CustomAttackerHandler = Exiled.API.Features.DamageHandlers.AttackerDamageHandler;
using DamageHandlerBase = PlayerStatsSystem.DamageHandlerBase;

namespace PeutiPlugin
{
    public class EventHandlers : IDisposable
    {
        private BroadcastPlugin _pluginInstance;
        public EventHandlers(BroadcastPlugin pluginInstance) => _pluginInstance = pluginInstance;
        internal void OnRoundStarting()
        {
            if (!_pluginInstance.Config.IsEnabled) return;
            Map.Broadcast(10, "<color=orange>라운드가 시작되었습니다.</color>");
        }


    

    internal void OnAnnouncingDecontamination(AnnouncingDecontaminationEventArgs ev)
        {
            switch (ev.Id)
            {
                case 0:
                    {
                        Map.Broadcast(10, "<size=33><color=red>저위험군 격리 절차</color> 실행까지 <color=red>15분</color> 남았습니다.</size>");
                        break;
                    }
                case 1:
                    {
                        Map.Broadcast(10, "<size=33><color=red>저위험군 격리 절차</color> 실행까지 <color=red>10분</color> 남았습니다.</size>");
                        break;
                    }
                case 2:
                    {
                        Map.Broadcast(10, "<size=33><color=red>저위험군 격리 절차</color> 실행까지 <color=red>5분</color> 남았습니다.</size>");
                        break;
                    }
                case 3:
                    {
                        Map.Broadcast(10, "<size=33><color=red>저위험군 격리 절차</color> 실행까지 <color=red>1분</color> 남았습니다.\n저위험군에 남아있는 인원은 신속히 대피하시기 바랍니다.</size>");
                        break;
                    }
                case 4:
                    {
                        Map.Broadcast(10, "<size=33><color=red>저위험군 격리 절차</color> 실행까지 <color=red>30초</color> 남았습니다.\n저위험군에 남아있는 인원은 신속히 대피하시기 바랍니다.</size>");
                        break;
                    }
            }
        }

        internal void OnDecontaminating(DecontaminatingEventArgs ev)
        {
            Map.Broadcast(10, "<color=red><size=33>저위험군 격리 절차</color>가 시작되었습니다.</size>");
        }


        internal void OnAnnouncingNtfEntrance(AnnouncingNtfEntranceEventArgs ev)
        {
            Map.Broadcast(10, $"<size=33><color=blue>기동특무부대 {ev.UnitName}-{ev.UnitNumber}</color>이 시설 내에 진입했습니다.\n재격리 대기 중인 <color=red>SCP</color>개체는 <color=red>{ev.ScpsLeft}</color>마리입니다.</size>");
        }



    








        public void Dispose()
        {
            _pluginInstance = null;
        }
    }
}