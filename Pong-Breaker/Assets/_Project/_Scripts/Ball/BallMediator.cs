using UnityEngine;

namespace Pong_Breaker
{
    public class BallMediator : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 10f; // [m/s
        [SerializeField] private float collisionSpeedModifier = 1f; // [m/s

        public Rigidbody Body { get; private set; }

        #region UnityEvents
        private void Awake()
        {
            Body = transform.root.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Body.AddForce(Body.transform.forward * initialSpeed, ForceMode.VelocityChange);
        }
        #endregion

        public void CollideWithHeight(float collisionHeight)
        {
            Body.AddForce(Vector3.up * collisionHeight * collisionSpeedModifier, ForceMode.VelocityChange);
        }

        public void OverwriteVelocity(Vector3 newVelocity)
        {
            Body.velocity = newVelocity;
        }
    }
}
