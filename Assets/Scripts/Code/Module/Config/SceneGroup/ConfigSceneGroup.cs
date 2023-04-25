﻿using System.Collections.Generic;
using LitJson.Extensions;
using Nino.Serialization;
using UnityEngine;
using Sirenix.OdinInspector;

namespace TaoTie
{
    [NinoSerialize]
    public partial class ConfigSceneGroup
    {
        [NinoMember(1)]
        [PropertyOrder(int.MinValue)]
        public ulong Id;
#if UNITY_EDITOR
        [SerializeField] [LabelText("策划备注")] [PropertyOrder(int.MinValue + 1)]
        private string Remarks;
#endif
        [NinoMember(2)]
        [Tooltip("实体")]
        public ConfigSceneGroupActor[] Actors;
        [NinoMember(3)]
        [Tooltip("触发区域")]
        public ConfigSceneGroupZone[] Zones;
        [NinoMember(4)]
        [Tooltip("事件监听")]
        public ConfigSceneGroupTrigger[] Triggers;
        [NinoMember(5)]
        [Tooltip("组")]
        public ConfigSceneGroupSuites[] Suites;
        [NinoMember(6)]
        [Tooltip("寻路路径")]
        public ConfigRoute[] Route;
        [NinoMember(7)]
        [LabelText("是否初始随机一个组？")]
        public bool RandSuite;
        [NinoMember(8)]
        [LabelText("初始组")]
        [ShowIf("@!"+nameof(RandSuite))] [ValueDropdown("@OdinDropdownHelper.GetSceneGroupSuiteIds()")]
        public int InitSuite;
    }
}