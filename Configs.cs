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

        [Description("이 기능은 그냥 냅두시면 됩니다(사용되지 않음)")]
        public bool QuitEqualsSuicide { get; private set; } = true;


        [Description("scp격리 자살 메세지")]
        public Exiled.API.Features.Broadcast ScpSuicideMessage { get; private set; } = new Exiled.API.Features.Broadcast("<color=red>%scpname%</color>(이)가 격리되었습니다.. 원인: %reason%</color>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("SCP격리 메세지")]
        public Exiled.API.Features.Broadcast ScpDeathMessage { get; private set; } = new Exiled.API.Features.Broadcast("<color=red>%scpname%<</color>(이)가 격리되었습니다.. \n죽인사람:<color=red>%killername%</color>/원인: <color=red>%reason%</color>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("SCP-049-2의 죽음을 방송해야 합니까?")]
        public bool Scp0492DeathBroadcast { get; private set; } = false;

        [Description("096의 대상 알림 기능 지속시간을 몇초로 하실건가요?")]
        public ushort Scp096TargetMessageDuration { get; private set; } = 12;

        [Description("096의 대상 알림 기능이 활성화 하실건가요?")]
        public bool Scp096TargetNotifyEnabled { get; private set; } = true;


        [Description("096에 타겟이 될떄 메세지가 떠야하나요?")]
        public string Scp096TargetNotifyText { get; private set; } = "<color=red>경고:</color>\n<color=purple>당신은 096의 타켓입니다 도망가세요!!</color>";

        [Description("SCP가 중토퇴장씨 메세지를 보내실건가요?")]
        public bool ScpLeftMessageEnable { get; private set; } = true;


        [Description("SCP-106의 공격을 받은 플레이어에게 보내는 메세지")]
        public string CaughtHintText { get; set; } = "";

        [Description("106 한방 차원기능 힌트 지속시간(냅두시면 됩니다 메세지 안나옵니다)")]
        public float CaughtHintDuration { get; set; } = 5.0F;

        [Description("위 설명과 같은 (106 한방 차원기능 힌트 메세지 ~)")]
        public string EscapedHintText { get; set; } = "";

        [Description("그냥 냅두시면됩니다 (106 한방차원 관련)")]
        public float EscapedHintDuration { get; set; } = 5.0F;






    }
}





 
