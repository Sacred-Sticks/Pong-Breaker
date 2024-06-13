using UnityEngine;
using System.Collections.Generic;

namespace Pong_Breaker
{
    public class CollidableMediator : MonoBehaviour
    {
        private static Dictionary<Vector3, ICollidable> collidables = new Dictionary<Vector3, ICollidable>();

        private void Awake()
        {
            collidables.Clear();
        }

        public static void Register(ICollidable collidable, Vector3 position)
        {
            collidables.Add(position, collidable);
        }

        public static void Unregister(Vector3 position)
        {
            collidables.Remove(position);
        }

        public static ICollidable GetCollidable(Vector3 position)
        {
            return collidables.ContainsKey(position) ? collidables[position] : null;
        }
    }
}
