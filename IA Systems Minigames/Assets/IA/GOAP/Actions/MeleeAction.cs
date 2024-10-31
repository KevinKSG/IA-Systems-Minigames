using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using IA.GOAP.Config;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

namespace IA.GOAP.Actions
{
    public class MeleeAction : ActionBase<AttackData>, IInjectable
    {
        private AttackConfigSO AttackConfig;

        private ObjectPool<Melee> Pool;
        public override void Created()
        {
            Pool = new(CreateObject);
        }

        private Melee CreateObject()
        {
            return GameObject.Instantiate(AttackConfig.MeleePrefab);
        }

        public override void End(IMonoAgent agent, AttackData data)
        {
            agent.gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
            data.Animator.SetBool(id:AttackData.ATTACK,value:false);
        }

        public void Inject(DependencyInjector injector)
        {
            AttackConfig = injector.AttackConfig;
        }

        public override ActionRunState Perform(IMonoAgent agent, AttackData data, ActionContext context)
        {
            
            if(data.Timer < 0.7)
            {
                agent.gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
            }

            data.Timer -= context.DeltaTime;

            bool shouldAttack = data.Target != null && Vector3.Distance(a:data.Target.Position, b:agent.transform.position) <= AttackConfig.MeleeAttackRadius;

            agent.transform.LookAt(data.Target.Position);
            
            data.Animator.SetBool(id:AttackData.ATTACK,shouldAttack);

            return data.Timer > 0 ? ActionRunState.Continue : ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, AttackData data)
        {
            data.Timer = AttackConfig.AttackDelay;
            Melee instance = Pool.Get();
            instance.gameObject.SetActive(true);

            instance.transform.position = agent.transform.position + (agent.transform.forward * (agent.gameObject.GetComponent<NavMeshAgent>().stoppingDistance/2));
            instance.transform.forward = agent.transform.forward;

            if(Vector3.Distance(a: data.Target.Position, b: agent.transform.position) <= AttackConfig.MeleeAttackRadius)
            {
                agent.gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;
            }
            


        }
    }

}
