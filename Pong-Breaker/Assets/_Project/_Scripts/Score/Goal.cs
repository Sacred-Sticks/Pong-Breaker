using Kickstarter.DependencyInjection;
using UnityEngine;

namespace Pong_Breaker
{
    public class Goal : MonoBehaviour, ICollidable
    {
        [Inject] private ScoreMediator scoreMediator;

        [SerializeField] private ScoreMediator.ScoreTarget scoringTarget;
        [SerializeField] private int scoreValue = 10;

        public void OnTrigger(BallMediator ball)
        {
            scoreMediator.AddScore(scoringTarget, scoreValue);
        }
    }
}