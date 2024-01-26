using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using Exiled.Events;
using Exiled.Events.Handlers;
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

        [Description("NTF 지원 자막 메세지(사이즈 조정하고 싶을시/ <size=바꾸고싶은크기>여기는 내용 그대로 넣으시면 됩니다</size> (예시: <size=33>NTF 지원이 왔습니다</size>)\n 콘피그에서 12는 지속시간 입니다.")]
        public Exiled.API.Features.Broadcast NTfAnnouncingMessage { get; private set; } = new Exiled.API.Features.Broadcast("<size=33><color=blue>기동특무부대</color> <color=blue>%ntfname%-%ntfnumber$</color>이 시설 내에 진입하였습니다. \n재격리 대기중인 <color=red>SCP</color>는 <color=red>%scpleft%</color>마리 입니다.</size>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("체포킬 메세지(사이즈 조정하고 싶을시/ <size=바꾸고싶은크기>여기는 내용 그대로 넣으시면 됩니다</size> (예시: <size=33>체포킬 하셨습니다</size>)\n 콘피그에서 12는 지속시간 입니다.")]
        public Exiled.API.Features.Broadcast cuffedkillmessage { get; private set; } = new Exiled.API.Features.Broadcast("<size=33><color=red>%Attacker%</color>님이 <color=yellow>%player%님을 체포킬 하셨습니다.\n신고용 URL:%url%</size>", 12, true, Broadcast.BroadcastFlags.Normal);

        [Description("핵폭탄 실행메세지(사이즈 조정하고 싶을시/ <size=바꾸고싶은크기>여기는 내용 그대로 넣으시면 됩니다</size> (예시: <size=33>핵폭탄이 실행되었습니다. 하셨습니다</size>)\n 콘피그에서 8는 지속시간 입니다.")]
        public Exiled.API.Features.Broadcast starthack { get; private set; } = new Exiled.API.Features.Broadcast("<size=33><color=red>알파탄두 핵탄두</color>가 실행되었습니다. \n실행한 사람: %player%(%rolename%)</size>", 8, true, Broadcast.BroadcastFlags.Normal);

        [Description("핵폭탄 중단 메세지(사이즈 조정하고 싶을시/ <size=바꾸고싶은크기>여기는 내용 그대로 넣으시면 됩니다</size> (예시: <size=33>핵폭탄이 중단되었습니다.</size>)\n 콘피그에서 8는 지속시간 입니다.")]
        public Exiled.API.Features.Broadcast stophack { get; private set; } = new Exiled.API.Features.Broadcast("<size=33><color=red>알파탄두 핵탄두</color>가 중단되었습니다. \n중단한 사람: %player%(%rolename%)</size>", 8, true, Broadcast.BroadcastFlags.Normal);


        [Description("SCP-049-2의 죽음을 방송해야 합니까?")]
        public bool Scp0492DeathBroadcast { get; private set; } = false;

        [Description("096의 대상 알림 기능 지속시간을 몇초로 하실건가요?")]
        public ushort Scp096TargetMessageDuration { get; private set; } = 12;

        [Description("096의 대상 알림 기능이 활성화 하실건가요?")]
        public bool Scp096TargetNotifyEnabled { get; private set; } = true;


        [Description("096에 타겟이 될떄 메세지가 떠야하나요?")]
        public string Scp096TargetNotifyText { get; private set; } = "<color=red>경고:</color>\n<color=purple>당신은 096의 타켓입니다 도망가세요!!</color>";

        [Description("Should SCP Leave message be shown?")]
        public bool ScpLeftMessageEnable { get; private set; } = true;


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






 
