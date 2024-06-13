using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Kickstarter.Extensions;
using Kickstarter.DependencyInjection;

namespace Pong_Breaker
{
    [RequireComponent(typeof(UIDocument))]
    public class ScoreMediator : MonoBehaviour, IDependencyProvider
    {
        [Provide] private ScoreMediator scoreMediator => this;

        [SerializeField] private StyleSheet stylesheet;

        private readonly Dictionary<ScoreTarget, Label> playerScores = new Dictionary<ScoreTarget, Label>();

        // storing scores statically so that the scene can be reloaded without losing the scores
        private static int player1Score = 0;
        private static int player2Score = 0;

        private const string containerStr = "container";
        private const string scoreStr = "score";

        private void Start()
        {
            BuildDocument();
        }

        private void BuildDocument()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            root.Clear();
            root.styleSheets.Add(stylesheet);

            var container = root.CreateChild<VisualElement>(containerStr);
            playerScores.Add(ScoreTarget.Player1, container.CreateChild<Label>(scoreStr));
            playerScores.Add(ScoreTarget.Player2, container.CreateChild<Label>(scoreStr));

            playerScores[ScoreTarget.Player1].text = player1Score.ToString();
            playerScores[ScoreTarget.Player2].text = player2Score.ToString();
        }

        public enum ScoreTarget
        {
            Player1,
            Player2,
        }

        public void AddScore(ScoreTarget target, int modification)
        {
            int score = 0;
            switch (target)
            {
                case ScoreTarget.Player1:
                    player1Score += modification;
                    score = player1Score;
                    break;
                case ScoreTarget.Player2:
                    player2Score += modification;
                    score = player2Score;
                    break;
            }
            playerScores[target].text = score.ToString();
        }
    }
}