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
    public class AmmunitionAction : ActionBase<AmmunitionAction.Data>, IInjectable
    {
        private BioSignsSO BioSigns;
        private static readonly int IS_RECHARGING = Animator.StringToHash(name: "isRecharging");
        public override void Created()
        {
            
        }

        public override void End(IMonoAgent agent, Data data)
        {
            data.Animator.SetBool(id: IS_RECHARGING, value: false);
            data.Bullets.enabled = true;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;
            data.Bullets.Bullets += context.DeltaTime * BioSigns.BulletsRestorationRate;
            
            data.Animator.SetBool(id: IS_RECHARGING, value: true);
            //Debug.Log(data.Target);
            //Debug.Log(data.Animator.GetBool(id: IS_EATING));
            if (data.Target == null || data.Bullets.Bullets >= 20)
            {
                if(data.Bullets.Bullets > 20)
                {
                    data.Bullets.Bullets = 20;
                }
                return ActionRunState.Stop;
            }

            return ActionRunState.Continue;
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Bullets.enabled = false;
            data.Timer = 1f;
        }

        public class Data : CommonData
        {
            [GetComponent]
            public Animator Animator { get; set; }
            [GetComponent]
            public BulletBehavior Bullets { get; set; }
        }

        public void Inject(DependencyInjector injector)
        {
            BioSigns = injector.BioSigns;
        }
    }

}
