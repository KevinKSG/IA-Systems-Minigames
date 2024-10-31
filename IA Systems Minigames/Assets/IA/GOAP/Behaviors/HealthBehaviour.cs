using System;
using CrashKonijn.Goap.Behaviours;
using IA.GOAP.Config;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IA.GOAP.Behaviors
{

    public class HealthBehaviour : MonoBehaviour
    {
        [field: SerializeField] public float Health { get; set; }
        [SerializeField] private BioSignsSO BioSigns;

        private void Awake()
        {
            Health = 100f;
        }

        private void Update()
        {
            //Health -= Time.deltaTime * BioSigns.HealthDepletionRate;
        }

        public void getRangeDamage()
        {
            Health -= 2f;
        }

        public void getMeleeDamage()
        {
            Health -= 5f;
        }
    }

}
