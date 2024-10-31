using CrashKonijn.Goap.Behaviours;
using IA.GOAP.Actions;
using IA.GOAP.Config;
using IA.GOAP.Goals;
using IA.GOAP.WorldKeys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA.GOAP.Behaviors
{
    [RequireComponent(typeof(AgentBehaviour))]
    public class AIBrain : MonoBehaviour
    {
        [SerializeField] private PlayerSensor PlayerSensor;
        [SerializeField] private AttackConfigSO AttackConfig;
        [SerializeField] private HealthBehaviour Health;
        [SerializeField] private BulletBehavior Bullet;
        [SerializeField] private BioSignsSO BioSigns;
        private AgentBehaviour agentBehaviour;
        private bool PlayerIsInRange;

        private void Awake()
        {
            agentBehaviour = GetComponent<AgentBehaviour>();
            
        }

        private void Start()
        {
            agentBehaviour.SetGoal<WanderGoal>(endAction: false);

            PlayerSensor.Collider.radius = AttackConfig.SensorRadius;
        }

        private void Update()
        {
            SetGoal();
        }

        private void SetGoal()
        {
            if (Health.Health < BioSigns.MinHealth)
            {
                agentBehaviour.SetGoal<EatGoal>(endAction: true);
            }
            else if (Health.Health > BioSigns.AcceptableHealthLimit && PlayerIsInRange)
            {
                agentBehaviour.SetGoal<KillPlayer>(endAction: false);
            }
            else if ((agentBehaviour.CurrentGoal is EatGoal && !PlayerIsInRange) || (agentBehaviour.CurrentGoal is KillPlayer && !PlayerIsInRange) || (agentBehaviour.CurrentGoal==null))
            {
                agentBehaviour.SetGoal<WanderGoal>(endAction: false);
            }
        }

        private void OnEnable()
        {
            PlayerSensor.OnPlayerEnter += PlayerSensorOnPlayerEnter;
            PlayerSensor.OnPlayerExit += PlayerSensorOnPlayerExit;
        }

        private void OnDisable()
        {
            PlayerSensor.OnPlayerEnter -= PlayerSensorOnPlayerEnter;
            PlayerSensor.OnPlayerExit -= PlayerSensorOnPlayerExit;
        }

        private void PlayerSensorOnPlayerExit(Vector3 LastPosition)
        {
            PlayerIsInRange = false;
            Debug.Log("PlayerIsInRange: " + PlayerIsInRange);
            if(Health.Health > 0 && agentBehaviour.CurrentGoal is EatGoal)
            {
                return;
            }

            agentBehaviour.SetGoal<WanderGoal>(endAction:true);
        }
        private void PlayerSensorOnPlayerEnter(Transform Player)
        {
            PlayerIsInRange = true;
            Debug.Log("PlayerIsInRange: " + PlayerIsInRange);
            if (Health.Health > BioSigns.AcceptableHealthLimit && agentBehaviour.CurrentGoal is EatGoal)
            {
                return;
            }

            agentBehaviour.SetGoal<KillPlayer>(endAction:true);
        }

        
    }
}

