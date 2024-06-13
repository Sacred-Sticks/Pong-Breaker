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
            var collidable = CollidableMediator.GetCollidable(collision.transform.position);
            collidable?.OnCollision(ballMediator);
        }

        private void OnTriggerEnter(Collider other)
        {
            var collidable = CollidableMediator.GetCollidable(other.transform.position);
            collidable?.OnTrigger(ballMediator);
        }
    }
}
