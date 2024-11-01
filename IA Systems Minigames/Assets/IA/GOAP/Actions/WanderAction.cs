using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using IA.GOAP.Config;
using IA.GOAP.WorldKeys;
using UnityEngine;

namespace IA.GOAP.Actions
{
    public class WanderAction : ActionBase<CommonData>, IInjectable
    {
        private WanderConfigSO WanderConfig;
        public override void Created()
        {
            
        }

        public override void End(IMonoAgent agent, CommonData data)
        {
            
        }

        public override ActionRunState Perform(IMonoAgent agent, CommonData data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if(data.Timer > 0)
            {
                return ActionRunState.Continue;
            }

            return ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, CommonData data)
        {
            data.Timer = Random.Range(WanderConfig.WaitRangeBetweenWanders.x, WanderConfig.WaitRangeBetweenWanders.y);
        }

        public void Inject(DependencyInjector injector)
        {
            WanderConfig = injector.WanderConfig;
        }
    }
}


