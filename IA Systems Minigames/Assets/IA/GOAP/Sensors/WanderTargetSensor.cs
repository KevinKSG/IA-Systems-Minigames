using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using IA.GOAP.Config;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace IA.GOAP.Sensors
{
    public class WanderTargetSensor : LocalTargetSensorBase, IInjectable
    {
        private WanderConfigSO WanderConfig;

        public override void Created()
        {
            
        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            
            Vector3 position = GetRandomPosition(agent);

            return new PositionTarget(position);
        }

        private Vector3 GetRandomPosition(IMonoAgent agent)
        {
            int count = 0;
            
            while(count < 5)
            {
                Vector2 random = Random.insideUnitCircle * WanderConfig.WanderRadius;
                
                Vector3 position = agent.transform.position + new Vector3(
                    random.x,
                    y: 0,
                    z:random.y
                    );

                if (NavMesh.SamplePosition(position, out NavMeshHit hit, maxDistance:40, areaMask:NavMesh.AllAreas))
                {
                    return hit.position;
                }
                count++;
            }

            
            return agent.transform.position;
        }

        public override void Update()
        {
            
        }

        public void Inject(DependencyInjector injector)
        {
            WanderConfig = injector.WanderConfig;
        }
    }

}
