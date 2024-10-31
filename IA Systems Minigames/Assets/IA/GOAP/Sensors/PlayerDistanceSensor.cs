using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using IA.GOAP.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA.GOAP.Sensors
{
    public class PlayerDistanceSensor : LocalWorldSensorBase, IInjectable
    {

        private AttackConfigSO AttackConfig;
        private Collider[] Colliders = new Collider[1];

        public override void Created()
        {
            
        }

        public void Inject(DependencyInjector injector)
        {
            AttackConfig = injector.AttackConfig;
        }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            if(Physics.OverlapSphereNonAlloc(agent.transform.position,AttackConfig.SensorRadius,Colliders,(int)AttackConfig.AttackableLayerMask) > 0 && Colliders[0].TryGetComponent(out PlayerController player))
            {
                return new SenseValue(Mathf.CeilToInt(f:Vector3.Distance(a:agent.transform.position,b:player.transform.position)));
            }

            return (SenseValue)int.MaxValue;
        }

        public override void Update()
        {
            
        }
    }

}
