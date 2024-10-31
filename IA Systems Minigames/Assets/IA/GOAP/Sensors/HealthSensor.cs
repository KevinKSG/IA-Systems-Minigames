using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using IA.GOAP.Behaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA.GOAP.Sensors
{
    public class HealthSensor : LocalWorldSensorBase
    {
        public override void Created()
        {
            
        }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            return new SenseValue(Mathf.CeilToInt(references.GetCachedComponent<HealthBehaviour>().Health));
        }

        public override void Update()
        {
            
        }
    }
}

