using Exiled.API.Interfaces;
using Exiled.Events;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;
using DamageTypes = Exiled.API.Enums.DamageType;
using Log = Exiled.API.Features.Log;
using ZoneType = Exiled.API.Enums.ZoneType;

namespace PeutiPlugin
{
    public class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        [Description("마지막 생존 플레이어에게 알림을 보내시겠습니까?")]
        public bool NotifyLastPlayerAlive { get; private set; } = true;

        [Description("팀의 마지막 생존자에게 어떤 메시지가 표시되어야 합니까?")]
        public string LastPlayerAliveNotificationText { get; private set; } = "<color=red>경고:</color>\n<color=purple>당신은 당신 팀의 마지막 생존자입니다!</color>";

        [Description("마지막 플레이어 생존 메시지 기간(활성화된 경우)")]
        public ushort LastPlayerAliveMessageDuration { get; private set; } = 12;

        [Description("Are quits as SCP considered a warnable offence?")]
        public bool QuitEqualsSuicide { get; private set; } = true;

        [Description("If 079 trigger tesla for how many seconds player shouldn't get warned for suicide? (2 is enough for most of servers)")]
        public int Scp079TeslaEventWait { get; private set; } = 2;

        [Description("scp격리 자살 메세지")]
        public Exiled.API.Features.Broadcast ScpSuicideMessage { get; private set; } = new Exiled.API.Features.Broadcast("<color=red>%scpname%</color>(이)가 격리되었습니다.. 원인: %reason%</color>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("SCP격리 메세지")]
        public Exiled.API.Features.Broadcast ScpDeathMessage { get; private set; } = new Exiled.API.Features.Broadcast("<color=red>%scpname%<</color>(이)가 격리되었습니다.. \n죽인사람:<color=red>%killername%</color>/원인: <color=red>%reason%</color>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("SCP-049-2의 죽음을 방송해야 합니까?")]
        public bool Scp0492DeathBroadcast { get; private set; } = false;

        [Description("SCP-096 target message duration (if enabled)")]
        public ushort Scp096TargetMessageDuration { get; private set; } = 12;

        [Description("Is 096's notify target feature enabled?")]
        public bool Scp096TargetNotifyEnabled { get; private set; } = true;

        [Description("수갑의 소유자(그리고 수갑을 찬 플레이어의 동료)만이 수갑을 풀 수 있어야 합니까?")]
        public bool HandCuffOwnership { get; private set; } = false;

        [Description("Text shown if a player doesn't own the handcuffed player")]
        public Exiled.API.Features.Broadcast UnhandCuffDenied { get; private set; } = new Exiled.API.Features.Broadcast("<color=blue>귀하는 이 플레이어의 소유권이 없으므로 수갑을 풀 수 없습니다!</color>", 8, true, Broadcast.BroadcastFlags.Normal);


        [Description("Which message should be shown to who become SCP-096 target?")]
        public string Scp096TargetNotifyText { get; private set; } = "<color=red>경고:</color>\n<color=purple>당신은 096의 타켓입니다 도망가세요!!</color>";

        [Description("Should SCP Leave message be shown?")]
        public bool ScpLeftMessageEnable { get; private set; } = true;


   
    }
}





 
