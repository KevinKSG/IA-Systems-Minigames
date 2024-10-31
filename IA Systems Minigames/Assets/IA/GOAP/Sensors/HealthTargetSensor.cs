using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using IA.GOAP.Config;
using System.Linq;
using UnityEngine;

namespace IA.GOAP.Sensors
{
    public class HealthTargetSensor : LocalTargetSensorBase, IInjectable
    {
        private BioSignsSO BioSigns;
        private Collider[] Colliders = new Collider[5];

        public override void Created()
        {
            
        }

        public void Inject(DependencyInjector injector)
        {
            BioSigns = injector.BioSigns;
        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            Vector3 agentPosition = agent.transform.position;
            int hits = Physics.OverlapSphereNonAlloc(agentPosition,BioSigns.HealthSearchRadius, Colliders,(int)BioSigns.HealthLayer);

            if(hits == 0)
            {
                return null;
            }

            for(int i = Colliders.Length - 1; i > hits; i--)
            {
                Colliders[i] = null;
            }

            Colliders = Colliders.OrderBy(collider => collider == null ? 999 : (collider.transform.position - agent.transform.position).sqrMagnitude).ToArray();

            return new PositionTarget(Colliders[0].transform.position);
        }

        public override void Update()
        {
            
        }
    }
}

