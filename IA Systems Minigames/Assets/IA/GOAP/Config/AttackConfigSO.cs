using IA.GOAP.Actions;
using UnityEngine;

namespace IA.GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/Attack Config",fileName = "Attack Config",order = 1)]
    public class AttackConfigSO : ScriptableObject
    {
        public float SensorRadius = 10;
        public float MeleeAttackRadius = 1f;
        public int MeleeAttackCost = 1;
        public float AttackDelay = 1;
        public LayerMask AttackableLayerMask;
        public Melee MeleePrefab;
        public Shot ShotPrefab;
        public int RangeAttackCost = 1;
        public float RangeAttackRadius = 7;
    }

}
