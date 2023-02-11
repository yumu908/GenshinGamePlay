﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace TaoTie
{
    [Serializable][LabelText("立方")]
    public class ConfigGearZoneOBB : ConfigGearZone
    {
        [SerializeField] public Vector3 rotation;
        [SerializeField] public Vector3 size;

        public override Zone CreateZone(Gear gear)
        {
            var entity = gear.Parent.CreateEntity<Zone>();
            entity.AddComponent<GearZoneComponent, int, long>(localId, gear.Id);
            return entity;
        }
    }
}