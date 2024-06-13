using UnityEngine;

namespace Pong_Breaker
{
    public interface ICollidable
    {
        public bool OnCollision(BallMediator ball, Collision collision) { return false; }
        public void OnTrigger(BallMediator ball) { }
    }
}
