using Kickstarter.DependencyInjection;
using UnityEngine;

namespace Pong_Breaker
{
    public class Brick : MonoBehaviour, ICollidable
    {
        [Inject] private ScoreMediator scoreMediator;

        [SerializeField] private int brickValue = 1;

        public bool OnCollision(BallMediator ball, Collision collision)
        {
            scoreMediator.AddScore(ball.LastTouched, brickValue);

            Destroy(gameObject);
            return true;
        }
    }
}
