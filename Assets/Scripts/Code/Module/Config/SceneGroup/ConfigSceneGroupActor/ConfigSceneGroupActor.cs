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
        [PropertyOrder(int.MinValue+1)]
        [SerializeField] [LabelText("策划备注")]
        private string Remarks;
#endif
        [NinoMember(1)]
        [PropertyOrder(int.MinValue)]
        public int LocalId;
        [NinoMember(2)]
        public Vector3 Position;
        [NinoMember(3)][ValueDropdown("@OdinDropdownHelper.GetCampTypeId()")]
        public uint CampId;
        
        public abstract Entity CreateActor(SceneGroup sceneGroup);
    }
}