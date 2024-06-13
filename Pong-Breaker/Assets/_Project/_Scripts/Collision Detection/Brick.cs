using UnityEngine;

namespace Pong_Breaker
{
    public class Brick : MonoBehaviour, ICollidable
    {
        public void OnCollision(Ball ball, Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
