using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.SystemControls;

namespace CoreGame
{
    namespace SystemMovements
    {
        public class PlayerMove
        {
            public static float rotation = 0f;

            public static void Move(Transform t, Rigidbody rb, Transform cam, float speed)
            {
                Vector3 camF = cam.forward;
                Vector3 camR = cam.right;
                camF.y = 0;
                camR.y = 0;
                camF = camF.normalized;
                camR = camR.normalized;

                Vector3 movement = (camF * Controllers.Axis.z + camR * Controllers.Axis.x) * Time.deltaTime * speed;
                movement.y = rb.velocity.y;
                rb.velocity = movement;

                if(movement != Vector3.zero)
                {
                    t.rotation = Quaternion.LookRotation(movement);
                }
            }

            /*
            public static void MoveForward(Rigidbody rb, float speed, Transform t)
            {
                rb.velocity = t.forward * speed * Controllers.AxisDeltaTime.y;
            }
            
            public static void JumpUp(Rigidbody rb, float jumpForce)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }*/

        }
    }
}