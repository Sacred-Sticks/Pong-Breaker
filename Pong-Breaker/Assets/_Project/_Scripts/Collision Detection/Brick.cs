using UnityEngine;

namespace Pong_Breaker
{
    public class Brick : MonoBehaviour, ICollidable
    {
        public bool OnCollision(BallMediator ball, Collision collision)
        {
            Destroy(gameObject);
            return true;
        }
    }
}
