using UnityEngine;

namespace IA.GOAP.Behaviors
{
    public class ShotBehavior : MonoBehaviour
    {
        [field: SerializeField] private Transform SpawnLocation;

        public delegate void SpawnShotEvent(Vector3 spawnLocation,Vector3 forward);

        public event SpawnShotEvent OnSpawnShot;

        public void BeginShot(int _)
        {
            OnSpawnShot?.Invoke(SpawnLocation.position,SpawnLocation.forward);
        }
    }

}
