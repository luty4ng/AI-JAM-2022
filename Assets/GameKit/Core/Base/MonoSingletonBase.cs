using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameKit;

namespace GameKit
{
    public abstract class MonoSingletonBase<T> : MonoBehaviour where T : MonoSingletonBase<T>
    {
        private static T Current;
        public static T current
        {
            get
            {
                if (Current == null)
                    Debug.LogError($"Mono Singleton Is Not Initialized.");
                return Current;
            }
        }

        private void Awake()
        {
            if (Current == null)
                Current = this as T;
            OnAwake();
        }
        protected virtual void OnAwake() {}
    }
}


