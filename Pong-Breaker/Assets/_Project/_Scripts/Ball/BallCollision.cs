using UnityEngine;

namespace Pong_Breaker
{
    public class BallCollision : MonoBehaviour
    {
        Ball ballMediator;

        private void Awake()
        {
            ballMediator = GetComponentInChildren<Ball>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collidable = collision.transform.root.GetComponentInChildren<ICollidable>();
            collidable?.OnCollision(ballMediator, collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            var collidable = other.transform.root.GetComponentInChildren<ICollidable>();
            collidable?.OnTrigger(ballMediator);
        }
    }
}
