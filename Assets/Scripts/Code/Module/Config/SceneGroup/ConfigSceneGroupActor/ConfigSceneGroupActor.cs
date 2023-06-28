﻿using System;
using LitJson.Extensions;
using Nino.Serialization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TaoTie
{
    public abstract class ConfigSceneGroupActor
    {
#if UNITY_EDITOR
        [PropertyOrder(int.MinValue+1)][NinoMember(0)]
        [LabelText("策划备注")]
        public string Remarks;
#endif
        [NinoMember(1)]
        [PropertyOrder(int.MinValue)]
        public int LocalId;
        [NinoMember(2)]
        public Vector3 Position;
        [NinoMember(3)]
        public Vector3 Rotation;
        [NinoMember(4)][LabelText("是否是相对坐标、方向")]
        public bool IsLocal = true;
        [NinoMember(5)]
        [ValueDropdown("@"+nameof(OdinDropdownHelper)+"."+nameof(OdinDropdownHelper.GetCampTypeId)+"()")]
        public uint CampId;
        
        public abstract Entity CreateActor(SceneGroup sceneGroup);
    }
}