using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IA.GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/BioSigns Config", fileName = "BioSigns Config", order = 3)]
    public class BioSignsSO : ScriptableObject
    {
        public float HealthSearchRadius = 30f;
        public LayerMask HealthLayer;
        public float HealthRestorationRate = 5f;
        public float HealthDepletionRate = 0.25f;
        public float MinHealth = 20;
        public float AcceptableHealthLimit = 40;

        public float AmmunitionSearchRadius = 30f;
        public LayerMask AmmunitionLayer;
        public float BulletsRestorationRate = 1f;
        public float BulletsDepletionRate = 0.01f;
        public float MinBullets = 10;
        public float AcceptableBulletsLimit = 20;
    }

}
