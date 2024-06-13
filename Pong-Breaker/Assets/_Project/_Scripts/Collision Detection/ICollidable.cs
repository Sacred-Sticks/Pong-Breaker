using UnityEngine;

namespace Pong_Breaker
{
    public interface ICollidable
    {
        public void OnCollision(Ball ball, Collision collision) { }
        public void OnTrigger(Ball ball) { }
    }
}
