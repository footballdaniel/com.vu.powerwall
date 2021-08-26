using UnityEngine;

namespace Powerwall
{
    public abstract class MotionTracker: MonoBehaviour
    {
        public abstract Vector3 GetPosition();
    }
}