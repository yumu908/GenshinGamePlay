﻿namespace TaoTie
{
    public class AttachToStateIDMixin : AbilityMixin
    {
        public ConfigAttachToStateIDMixin config => baseConfig as ConfigAttachToStateIDMixin;

        private Fsm fsm;
        private bool hasAddModifier;
        private Entity owner;
        private AbilityComponent abilityComponent;
        public override void Init(ActorAbility actorAbility, ActorModifier actorModifier, ConfigAbilityMixin config)
        {
            base.Init(actorAbility, actorModifier, config);
            owner = actorAbility.Parent.GetParent<Entity>();
            fsm = owner?.GetComponent<FsmComponent>()?.GetFsm(this.config.ChargeLayer);
            abilityComponent = owner?.GetComponent<AbilityComponent>();
            if (fsm != null)
            {
                fsm.onStateChanged += OnStateChanged;
                if (this.config.StateIDs.Contains(fsm.currentStateName))
                {
                    ApplyModifier();
                }
            }
        }

        private void OnStateChanged(string from, string to)
        {
            if (config.StateIDs == null || abilityComponent == null)
                return;

            bool flag = config.StateIDs.Contains(from), flag2 = config.StateIDs.Contains(to);
            if (!flag && flag2)
            {
                ApplyModifier();
            }
            else if (flag && !flag2)
            {
                RemoveModifier();
            }
        }

        private void ApplyModifier()
        {
            if (EvaluatePredicate())
            {
                abilityComponent.ApplyModifier(owner.Id, actorAbility, config.ModifierName);
                hasAddModifier = true;
            }
        }

        private bool EvaluatePredicate()
        {
            if (config.Predicate != null)
            {
                return config.Predicate.Evaluate(owner, actorAbility, actorModifier, owner);
            }
            return true;
        }

        private void RemoveModifier()
        {
            if (hasAddModifier)
            {
                abilityComponent.RemoveModifier(actorAbility.Config.AbilityName, config.ModifierName);
            }

            hasAddModifier = false;
        }

        public override void Dispose()
        {
            if (fsm != null)
            {
                fsm.onStateChanged -= OnStateChanged;
                fsm = null;
            }

            hasAddModifier = false;
            abilityComponent = null;
            owner = null;
            base.Dispose();
        }
    }
}