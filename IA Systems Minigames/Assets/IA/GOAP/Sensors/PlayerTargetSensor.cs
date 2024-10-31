using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using IA.GOAP.Config;
using UnityEngine;

namespace IA.GOAP.Sensors
{
    public class PlayerTargetSensor : LocalTargetSensorBase, IInjectable
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

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            
            if (Physics.OverlapSphereNonAlloc(agent.transform.position,AttackConfig.SensorRadius,Colliders,(int)AttackConfig.AttackableLayerMask) > 0)
            {
                return new TransformTarget(Colliders[0].transform);
            }

            return null;
        }

        public override void Update()
        {

        }
    }

}
