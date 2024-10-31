using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using IA.GOAP.Behaviors;
using IA.GOAP.Config;
using System.Data.Common;
using UnityEngine;

namespace IA.GOAP.Actions
{
    public class EatAction : ActionBase<EatAction.Data>, IInjectable
    {
        private BioSignsSO BioSigns;
        private static readonly int IS_EATING = Animator.StringToHash(name:"IsEating");
        public override void Created()
        {
            
        }

        public override void End(IMonoAgent agent, Data data)
        {
            data.Animator.SetBool(id: IS_EATING, value: false);
            data.Health.enabled = true;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;
            data.Health.Health += context.DeltaTime * BioSigns.HealthRestorationRate;
            
            data.Animator.SetBool(id: IS_EATING, value: true);
            //Debug.Log(data.Target);
            //Debug.Log(data.Animator.GetBool(id: IS_EATING));
            if (data.Target == null || data.Health.Health >= 100)
            {
                if(data.Health.Health > 100)
                {
                    data.Health.Health = 100;
                }
                return ActionRunState.Stop;
            }

            return ActionRunState.Continue;
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Health.enabled = false;
            data.Timer = 1f;
        }

        public class Data : CommonData
        {
            [GetComponent]
            public Animator Animator { get; set; }
            [GetComponent]
            public HealthBehaviour Health { get; set; }
        }

        public void Inject(DependencyInjector injector)
        {
            BioSigns = injector.BioSigns;
        }
    }

}
