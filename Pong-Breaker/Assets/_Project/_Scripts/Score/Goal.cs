using Kickstarter.Bootstrapper;
using Kickstarter.DependencyInjection;
using System.Collections;
using UnityEngine;

namespace Pong_Breaker
{
    public class Goal : MonoBehaviour, ICollidable
    {
        [Inject] private SceneLoader sceneLoader;
        [Inject] private ScoreMediator scoreMediator;

        [SerializeField] private ScoreMediator.ScoreTarget scoringTarget;
        [SerializeField] private int scoreValue = 10;

        private const float reloadDelay = 0.5f;

        public void OnTrigger(BallMediator ball)
        {
            scoreMediator.AddScore(scoringTarget, scoreValue);
            StartCoroutine(ReloadScene());
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(reloadDelay);
            sceneLoader.LoadSceneGroup("Gameplay");
        }
    }
}