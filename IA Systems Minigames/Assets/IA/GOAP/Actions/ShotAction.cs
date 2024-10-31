using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Behaviours;
using IA.GOAP.Behaviors;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using UnityEngine.Pool;
using IA.GOAP.Config;
using UnityEngine;

namespace IA.GOAP.Actions
{
    public class ShotAction : ActionBase<ShotAction.Data>, IInjectable
    {
        private AttackConfigSO AttackConfig;
        private ObjectPool<Shot> Pool;
        public override void Created()
        {
            Pool = new(CreateObject);
        }

        private Shot CreateObject()
        {
            return GameObject.Instantiate(AttackConfig.ShotPrefab);
        }

        public override void End(IMonoAgent agent, Data data)
        {
            data.Animator.SetBool(id:AttackData.ATTACK, value:false);
            data.ShotBehavior.OnSpawnShot -= ShotBehaviorOnSpawnShot;
        }

        public void Inject(DependencyInjector injector)
        {
            AttackConfig = injector.AttackConfig;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            
            data.Timer -= context.DeltaTime;

            bool shouldAttack = data.Target != null && Vector3.Distance(a:data.Target.Position, b:agent.transform.position) <= AttackConfig.RangeAttackRadius;

            agent.transform.LookAt(data.Target.Position);
            
            data.Animator.SetBool(id:AttackData.ATTACK,shouldAttack);

            return data.Timer > 0 ? ActionRunState.Continue : ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Timer = AttackConfig.AttackDelay;
            data.ShotBehavior.OnSpawnShot += ShotBehaviorOnSpawnShot;
            data.BulletBehavior.Bullets -= 1;
            Shot instance = Pool.Get();
            instance.gameObject.SetActive(true);

            //Debug.Log("Agent forward: " + agent.transform.forward);
            instance.transform.position = agent.transform.position + (agent.transform.forward * 3);
            //Debug.Log("Instance forward 1: " + instance.transform.forward);
            instance.transform.forward = agent.transform.forward;
            instance.Rigidbody.AddForce(instance.transform.forward * instance.Force, ForceMode.Impulse);
            //Debug.Log("Instance forward 2: " + instance.transform.forward);
            //Debug.Log(" ");

        }

        private void ShotBehaviorOnSpawnShot(Vector3 spawnLocation,Vector3 forward)
        {
            
            Shot instance = Pool.Get();
            

            instance.transform.position = spawnLocation;
            instance.transform.forward = forward;
        }

        public class Data : AttackData
        {
            [GetComponent]
            public ShotBehavior ShotBehavior { get; set; }
            [GetComponent]
            public BulletBehavior BulletBehavior { get; set; }
        }
    }

}
