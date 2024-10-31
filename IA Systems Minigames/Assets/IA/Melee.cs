using IA.GOAP.Behaviors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IA
{
    [RequireComponent(requiredComponent: typeof(Rigidbody), requiredComponent2: typeof(Collider))]
    public class Melee : MonoBehaviour
    {
        [SerializeField]
        private float AutoDestroyTime = 1f;

        private WaitForSeconds Wait;
        public Rigidbody Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            StopAllCoroutines();
            StartCoroutine(routine: DelayDisable());

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
            if (other.TryGetComponent(out PlayerController player))
            {

                player.getDamage(5.0f);
                gameObject.SetActive(false);
            }

            if (other.gameObject.layer == 7)
            {
                gameObject.SetActive(false);
            }

            if (other.gameObject.layer == 10)
            {
                other.gameObject.GetComponent<HealthBehaviour>().getMeleeDamage();
                gameObject.SetActive(false);
            }

        }

    }

}
