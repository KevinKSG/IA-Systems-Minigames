using CrashKonijn.Goap.Classes.References;
using UnityEngine;

namespace IA.GOAP.Actions
{
    public class AttackData : CommonData
    {
        public static readonly int ATTACK = Animator.StringToHash(name:"Attack");

        [GetComponent]
        public Animator Animator { get; set; }
    }

}
