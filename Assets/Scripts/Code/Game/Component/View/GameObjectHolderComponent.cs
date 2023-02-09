﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace TaoTie
{
    public partial class GameObjectHolderComponent:Component,IComponent
    {
        [Timer(TimerType.DestroyEffect)]
        public class DestroyEffectTimer: ATimer<EffectInfo>
        {
            public override void Run(EffectInfo self)
            {
                try
                {
                    self.Dispose();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.ConfigId}\n{e}");
                }
            }
        }
        public class EffectInfo:IDisposable
        {
            public static EffectInfo Create()
            {
                var res = ObjectPool.Instance.Fetch<EffectInfo>();
                res.IsDispose = false;
                return res;
            }

            private bool IsDispose;
            public GameObject obj;
            public int ConfigId;
            public GameObjectHolderComponent Parent;
            public long TimerId;
            public void Dispose()
            {
                if (IsDispose)
                {
                    return;
                }

                IsDispose = true;
                GameTimerManager.Instance.Remove(ref TimerId);
                Parent = default;
                ConfigId = default;
                GameObjectPoolManager.Instance.RecycleGameObject(obj);
                obj = null;
                ObjectPool.Instance.Recycle(this);
            }
        }
        public Transform EntityView;

        public Transform TriggerRoot;

        public ReferenceCollector Collector;

        DictionaryComponent<long, Collider> Triggers;

        DictionaryComponent<int, EffectInfo> Effects;
        #region override

        public void Init()
        {
            Triggers = DictionaryComponent<long, Collider>.Create();
            Effects = DictionaryComponent<int, EffectInfo>.Create();
            LoadGameObjectAsync().Coroutine();
        }

        public async ETTask LoadGameObjectAsync()
        {
            var unit = this.GetParent<Unit>();
            var obj = await GameObjectPoolManager.Instance.GetGameObjectAsync(unit.Config.Perfab);
            if (this.IsDispose)
            {
                GameObjectPoolManager.Instance.RecycleGameObject(obj);
                return;
            }

            Animator = obj.GetComponentInChildren<Animator>();
            EntityView = obj.transform;
            Collector = obj.GetComponent<ReferenceCollector>();
            EntityView.SetParent(this.Parent.Parent.GameObjectRoot);
            var ec = obj.GetComponent<EntityComponent>();
            if (ec == null) ec = obj.AddComponent<EntityComponent>();
            ec.Id = this.Id;

            ec.EntityType = unit.Type;
            GameObject tRoot = new GameObject("TriggerRoot");
            TriggerRoot = tRoot.transform;
            TriggerRoot.SetParent(EntityView);
            TriggerRoot.localPosition = Vector3.zero;
            EntityView.position = unit.Position;
            EntityView.rotation = unit.Rotation;
            Messager.Instance.AddListener<Unit,Vector3>(Id,MessageId.ChangePositionEvt,OnChanePosition);
            Messager.Instance.AddListener<Unit,Quaternion>(Id,MessageId.ChangeRotationEvt,OnChaneRotation);
            Messager.Instance.AddListener<Unit>(Id,MessageId.MoveStart,MoveStart);
            Messager.Instance.AddListener<Unit>(Id,MessageId.MoveStop,MoveStop);
            // var hud = unit.GetComponent<HudComponent>();
            // if (hud != null)
            // {
            //     HudSystem hudSys = ManagerProvider.GetManager<HudSystem>();
            //     hudSys?.ShowHeadInfo(hud.Info);
            // }
        }

        public void Destroy()
        {
            Messager.Instance.RemoveListener<Unit,Vector3>(Id,MessageId.ChangePositionEvt,OnChanePosition);
            Messager.Instance.RemoveListener<Unit,Quaternion>(Id,MessageId.ChangeRotationEvt,OnChaneRotation);
            Messager.Instance.RemoveListener<Unit>(Id,MessageId.MoveStart,MoveStart);
            Messager.Instance.RemoveListener<Unit>(Id,MessageId.MoveStop,MoveStop);
            foreach (var v in Triggers)
            {
                var value = v.Value;
                GameObject.DestroyImmediate(value.gameObject);
            }
            Triggers.Clear();
            Triggers = null;
            if(TriggerRoot!=null)
                GameObject.Destroy(TriggerRoot.gameObject);
            foreach (var v in Effects)
            {
                var value = v.Value;
                value.Dispose();
            }
            Effects.Clear();
            Effects = null;
            if(EntityView!=null)
                GameObjectPoolManager.Instance.RecycleGameObject(EntityView.gameObject);
        }

        #endregion

        public void OnChanePosition(Unit unit,Vector3 old)
        {
            EntityView.position = unit.Position;
        }

        public void OnChaneRotation(Unit unit, Quaternion old)
        {
            EntityView.rotation = unit.Rotation;
        }
    }
}