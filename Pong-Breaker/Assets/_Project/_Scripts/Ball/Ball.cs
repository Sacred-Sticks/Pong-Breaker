using UnityEngine;

namespace Pong_Breaker
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 10f; // [m/s

        private Rigidbody body;

        private void Awake()
        {
            body = transform.root.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            body.AddForce(body.transform.right * initialSpeed, ForceMode.VelocityChange);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collidable = CollidableMediator.GetCollidable(collision.transform.position);
            collidable?.OnCollisionEnter(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            var collidable = CollidableMediator.GetCollidable(other.transform.position);
            collidable?.OnTriggerEnter(this);
        }
    }
}
