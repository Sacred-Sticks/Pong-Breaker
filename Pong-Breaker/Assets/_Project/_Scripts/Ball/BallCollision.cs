using UnityEngine;

namespace Pong_Breaker
{
    public class BallCollision : MonoBehaviour
    {
        private const float speedMultiplier = 1.025f;

        BallMediator ballMediator;

        private void Awake()
        {
            ballMediator = GetComponentInChildren<BallMediator>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var collidable = collision.transform.root.GetComponentInChildren<ICollidable>();
            bool? brickHit = collidable?.OnCollision(ballMediator, collision);

            var relativeVelocity = collision.relativeVelocity;

            switch (brickHit)
            {
                case null:
                    relativeVelocity.x = -relativeVelocity.x;
                    break;
                case true:
                    break;
                case false:
                    relativeVelocity.y = -relativeVelocity.y;
                    relativeVelocity *= speedMultiplier;
                    break;
            }

            ballMediator.OverwriteVelocity(relativeVelocity);
        }

        private void OnTriggerEnter(Collider other)
        {
            var collidable = other.transform.root.GetComponentInChildren<ICollidable>();
            collidable?.OnTrigger(ballMediator);
        }
    }
}
