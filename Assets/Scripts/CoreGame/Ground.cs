using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#pragma warning disable 0649

namespace CoreGame
{
    namespace SystemGround
    {
        [Serializable]
        public class Ground
        {
            [SerializeField]
            Color rayColor = Color.red;
            [SerializeField, Range(0f, 10f)]
            float rayDistance;
            [SerializeField]
            LayerMask groundLayer;

            RaycastHit raycastHit;

            public RaycastHit RaycastHit
            {
                get
                {
                    return raycastHit;
                }
            }

            public void DrawRay(Transform t)
            {
                Gizmos.color = rayColor;
                Gizmos.DrawRay(t.position, -t.up * rayDistance);
            }

            public bool isGrounding(Transform t)
            {
                return Physics.Raycast(t.position, -t.up, out raycastHit, rayDistance, groundLayer);
            }
        }

    }
}
