namespace Pong_Breaker
{
    public interface ICollidable
    {
        public void OnCollisionEnter(Ball ball);
        public void OnTriggerEnter(Ball ball);
    }
}
