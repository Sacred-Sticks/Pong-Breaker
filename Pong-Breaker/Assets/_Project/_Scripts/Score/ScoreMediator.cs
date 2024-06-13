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

            foreach (var playerScore in playerScores)
                playerScore.Value.text = "0";
        }

        public enum ScoreTarget
        {
            Player1,
            Player2,
        }

        public void AddScore(ScoreTarget target, int modication)
        {
            int score = int.Parse(playerScores[target].text);
            score += modication;
            playerScores[target].text = score.ToString();
        }
    }
}