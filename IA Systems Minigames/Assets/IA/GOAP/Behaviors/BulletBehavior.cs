using IA.GOAP.Config;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IA.GOAP.Behaviors
{
    public class BulletBehavior : MonoBehaviour
    {
        [field: SerializeField] public float Bullets { get; set; }
        [SerializeField] private BioSignsSO BioSigns;

        private void Awake()
        {
            Bullets = Random.Range(5,10);
        }

        private void Update()
        {
            Bullets = Mathf.Clamp(value:Bullets - Time.deltaTime * BioSigns.BulletsDepletionRate, min:0, float.MaxValue);
        }
    }

}
