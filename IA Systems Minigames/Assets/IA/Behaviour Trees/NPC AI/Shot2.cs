using IA.GOAP.Behaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    [RequireComponent(requiredComponent: typeof(Rigidbody), requiredComponent2: typeof(Collider))]
    public class Shot2 : MonoBehaviour
    {
        [SerializeField]
        private float AutoDestroyTime = 10f;

        [SerializeField] public float Force = 100f;

        private WaitForSeconds Wait;
        public Rigidbody Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            StopAllCoroutines();
            StartCoroutine(routine:DelayDisable());
            
        }

        private IEnumerator DelayDisable()
        {
            
            

            if (Wait == null)
            {
                Wait = new WaitForSeconds(AutoDestroyTime);
            }

            yield return null;

            
            

            

            yield return Wait;
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            Rigidbody.angularVelocity = Vector3.zero;
            Rigidbody.velocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.gameObject);
            if(other.TryGetComponent(out PlayerController player))
            {

                player.loseGame();
                gameObject.SetActive(false);
            }

            if(other.gameObject.layer == 7)
            {
                gameObject.SetActive(false);
            }

        }

    }

}
