using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA.GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/Wander Config", fileName = "Wander Config", order = 2)]
    public class WanderConfigSO : ScriptableObject
    {
        public Vector2 WaitRangeBetweenWanders = new(x:1,y:5);
        public float WanderRadius = 5f;
    }

}
