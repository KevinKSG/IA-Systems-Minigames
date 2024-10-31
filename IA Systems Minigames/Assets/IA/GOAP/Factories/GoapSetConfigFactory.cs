using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;
using IA.GOAP.Actions;
using IA.GOAP.Goals;
using IA.GOAP.Sensors;
using IA.GOAP.Targets;
using IA.GOAP.WorldKeys;
using UnityEngine;
using System;

namespace IA.GOAP.Factories
{
    [RequireComponent(typeof(DependencyInjector))]
    public class GoapSetConfigFactory : GoapSetFactoryBase
    {
        private DependencyInjector injector;

        public override IGoapSetConfig Create()
        {
            injector = GetComponent<DependencyInjector>();
            GoapSetBuilder builder = new(name:"agentSet");

            BuildGoals(builder);
            BuildActions(builder);
            BuildSensors(builder);

            return builder.Build();
        }

        private void BuildGoals(GoapSetBuilder builder)
        {
            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual,amount:0);
                

            builder.AddGoal<KillPlayer>()
                .AddCondition<PlayerHealth>(Comparison.SmallerThanOrEqual, amount:0);

            builder.AddGoal<EatGoal>()
                .AddCondition<Health>(Comparison.GreaterThanOrEqual, amount:100);


        }

        private void BuildActions(GoapSetBuilder builder)
        {
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(EffectType.Increase)
                .SetBaseCost(1)
                .SetInRange(10);

            builder.AddAction<MeleeAction>()
                .AddCondition<PlayerDistance>(Comparison.SmallerThanOrEqual, amount: Mathf.FloorToInt(
                    injector.AttackConfig.MeleeAttackRadius))
                .SetTarget<PlayerTarget>()
                .AddEffect<PlayerHealth>(EffectType.Decrease)
                .SetBaseCost(injector.AttackConfig.MeleeAttackCost)
                .SetInRange(injector.AttackConfig.SensorRadius);

            builder.AddAction<ShotAction>()
                .AddCondition<Bullets>(Comparison.GreaterThanOrEqual, amount: 1)
                .AddCondition<PlayerDistance>(Comparison.GreaterThan, amount: Mathf.FloorToInt(
                    injector.AttackConfig.MeleeAttackRadius))
                .SetTarget<PlayerTarget>()
                .AddEffect<PlayerHealth>(EffectType.Decrease)
                .SetBaseCost(injector.AttackConfig.RangeAttackCost)
                .SetInRange(injector.AttackConfig.SensorRadius);

            builder.AddAction<EatAction>()
                .SetTarget<GrassTarget>()
                .AddEffect<Health>(EffectType.Increase)
                .SetBaseCost(8)
                .SetInRange(3);

            builder.AddAction<AmmunitionAction>()
                .AddCondition<PlayerDistance>(Comparison.GreaterThanOrEqual, amount: Mathf.FloorToInt(
                    injector.AttackConfig.MeleeAttackRadius))
                .SetTarget<AmmunitionTarget>()
                .AddEffect<Bullets>(EffectType.Increase)
                .SetBaseCost(4)
                .SetInRange(3);

        }

        private void BuildSensors(GoapSetBuilder builder)
        {
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();

            builder.AddTargetSensor<PlayerTargetSensor>()
                .SetTarget<PlayerTarget>();

            builder.AddTargetSensor<HealthTargetSensor>()
                .SetTarget<GrassTarget>();

            builder.AddWorldSensor<HealthSensor>()
                .SetKey<Health>();

            builder.AddWorldSensor<PlayerDistanceSensor>()
                .SetKey<PlayerDistance>();

            builder.AddWorldSensor<BulletsSensor>()
                .SetKey<Bullets>();

            builder.AddTargetSensor<AmmunitionTargetSensor>()
                .SetTarget<AmmunitionTarget>();
        }
    }
}


