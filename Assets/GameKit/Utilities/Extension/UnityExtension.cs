using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameKit
{
    
    public static partial class UnityExtension
    {
        private static List<Transform> s_CachedTransforms;
        public static Vector2 ToLocal(this Vector2 position, Transform transform)
        {
            return transform.InverseTransformPoint(position);
        }

        public static Vector3 ToLocal(this Vector3 position, Transform transform)
        {
            return transform.InverseTransformPoint(position);
        }

        public static void SetLayerRecursively(this GameObject gameObject, int layer)
    {
        gameObject.GetComponentsInChildren(true, s_CachedTransforms);
        for (int i = 0; i < s_CachedTransforms.Count; i++)
        {
            s_CachedTransforms[i].gameObject.layer = layer;
        }

        s_CachedTransforms.Clear();
    }
    }
}
