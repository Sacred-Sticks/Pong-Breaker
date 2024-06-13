namespace Pong_Breaker
{
    public interface ICollidable
    {
        public void OnCollision(Ball ball) { }
        public void OnTrigger(Ball ball) { }
    }
}
