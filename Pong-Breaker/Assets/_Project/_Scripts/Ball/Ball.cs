using UnityEngine;

namespace Pong_Breaker
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 10f; // [m/s

        public Rigidbody body { get; private set; }

        private void Awake()
        {
            body = transform.root.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            body.AddForce(body.transform.right * initialSpeed, ForceMode.VelocityChange);
        }
    }
}
