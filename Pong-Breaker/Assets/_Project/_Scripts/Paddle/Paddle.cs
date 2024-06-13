using Kickstarter.Inputs;
using UnityEngine;

namespace Pong_Breaker
{
    public class Paddle : MonoBehaviour, ICollidable, IInputReceiver
    {
        [SerializeField] private FloatInput movePaddle;
        [SerializeField] private float movementSpeed = 1f; // [m/s

        private float rawInput;

        // Readonly / Components
        private Rigidbody body;

        #region InputHandler
        public void RegisterInputs(Player.PlayerIdentifier playerIdentifier)
        {
            movePaddle.RegisterInput(OnMovePaddleInputChange, playerIdentifier);
        }

        public void DeregisterInputs(Player.PlayerIdentifier playerIdentifier)
        {
            movePaddle.DeregisterInput(OnMovePaddleInputChange, playerIdentifier);
        }

        private void OnMovePaddleInputChange(float input)
        {
            rawInput = input;
        }
        #endregion

        #region UnityEvents
        private void Awake()
        {
            body = transform.root.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            body.AddForce(new Vector3(0, rawInput * movementSpeed, 0) - body.velocity, ForceMode.VelocityChange);
        }
        #endregion

        #region ICollidable
        public bool OnCollision(BallMediator ball, Collision collision)
        {
            float collisionHeight = transform.InverseTransformPoint(collision.GetContact(0).point).y;
            ball.CollideWithHeight(collisionHeight);
            return false;
        }
        #endregion
    }
}
