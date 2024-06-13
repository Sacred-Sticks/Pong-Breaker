using UnityEngine;

namespace Pong_Breaker
{
    public class Brick : MonoBehaviour, ICollidable
    {
        private void Start()
        {
            CollidableMediator.Register(this, transform.position);
        }

        public void OnCollision(Ball ball)
        {
            Destroy(gameObject);
        }
    }
}
