using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
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


        [Description("096에 타겟이 될떄 메세지가 떠야하나요?")]
        public string Scp096TargetNotifyText { get; private set; } = "<color=red>경고:</color>\n<color=purple>당신은 096의 타켓입니다 도망가세요!!</color>";

        [Description("Should SCP Leave message be shown?")]
        public bool ScpLeftMessageEnable { get; private set; } = true;


        [Description("Should SCP list message be shown?")]
        public bool ScpListMessageEnable { get; private set; } = true;

        [Description("Should Cuffedkill message be shown?")]
        public bool CuffedkillMessageEnable { get; private set; } = true;

        [Description("SCP-106의 공격을 받은 플레이어에게 보내는 메세지")]
        public string CaughtHintText { get; set; } = "";

        [Description("Caught to PD player hint duration")]
        public float CaughtHintDuration { get; set; } = 5.0F;

        [Description("PD를 탈출한 플레이어에게 보내는 힌트")]
        public string EscapedHintText { get; set; } = "";

        [Description("Escaped PD hint duration")]
        public float EscapedHintDuration { get; set; } = 5.0F;





    }
}





 
