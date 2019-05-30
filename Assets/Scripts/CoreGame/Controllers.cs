using UnityEngine;

namespace CoreGame
{
    namespace SystemControls
    {
        public static class Controllers {
            static int connectedControllers = Input.GetJoystickNames().Length;
            static bool[,] joystickMoved = new bool[connectedControllers, 2];
            static bool[,] TriggerMoved = new bool[connectedControllers, 2];
            static bool[] padMoved = new bool[connectedControllers];

            /// <summary>
            /// Saber si un input Fire (default de Unity) fue presionado.
            /// </summary>
            /// <param name="n">Numero de Fire</param>
            /// <param name="type">Tipo de input: 0 = Button, 1 = ButtonDown, 2 = ButtonUp</param>
            /// <returns>Bool</returns>
            public static bool GetFire(int n, int type) {
                string input = "Fire" + n;
                switch (type) {
                    case 0: return Input.GetButton(input);
                    case 1: return Input.GetButtonDown(input);
                    case 2: return Input.GetButtonUp(input);
                }
                return false;
            }

            /// <summary>
            /// Obtener el Axis horizontal y vertical como un Vector3.
            /// </summary>
            public static Vector3 Axis {
                get {
                    return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                }
            }

            /// <summary>
            /// Obtener el Axis horizontal y vertical como un Vector3 multiplicado por Time.DeltaTime.
            /// </summary>
            public static Vector3 AxisDeltaTime {
                get {
                    return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime;
                }
            }

            /// <summary>
            /// Saber si un boton fue presionado.
            /// </summary>
            /// <param name="controller">Numero del control: 1 - 8</param>
            /// <param name="button">Nombre del boton: A, B, X, Y, LB, RB, Back, Start</param>
            /// <param name="type">Tipo de input: 0 = Button, 1 = ButtonDown, 2 = ButtonUp</param>
            /// <returns>Bool</returns>
            public static bool GetButton (int n, string button, int type) {
                string input = "Controller" + n + "_" + button;
                switch (type) {
                    case 0: return Input.GetButton(input);
                    case 1: return Input.GetButtonDown(input);
                    case 2: return Input.GetButtonUp(input);
                }
                return false;
            }

            /// <summary>
            /// Obtener el axis de un joystick.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <param name="j">Numero del joystick: 1 = izquierdo, 2 = derecho</param>
            /// <returns>Vector2</returns>
            public static Vector2 GetJoystick (int n, int j) {
                Vector2 axis = new Vector2(Input.GetAxis("Controller" + n + "_Joystick" + j + "_Horizontal"),
                                           Input.GetAxis("Controller" + n + "_Joystick" + j + "_Vertical"));
                if (axis != Vector2.zero) {
                    joystickMoved[n - 1, j - 1] = true;
                }
                return axis;
            }

            /// <summary>
            /// Verifica si un joystick regreso al centro despues de ser movido.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <param name="j">Numero del joystick: 1 = izquierdo, 2 = derecho</param>
            /// <returns>Bool</returns>
            public static bool JoystickReturnedCenter(int n, int j) {
                if (joystickMoved[n - 1, j - 1]) {
                    Vector2 axis = new Vector2(Input.GetAxis("Controller" + n + "_Joystick" + j + "_Horizontal"),
                                               Input.GetAxis("Controller" + n + "_Joystick" + j + "_Vertical"));
                    if (axis == Vector2.zero) {
                        joystickMoved[n - 1, j - 1] = false;
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Saber si el boton de un joystick fue presionado.
            /// </summary>
            /// <param name="controller">Numero del control: 1 - 8</param>
            /// <param name="j">Numero del joystick: 1 = izquierdo, 2 = derecho</param>
            /// <param name="type">Tipo de input: 0 = Button, 1 = ButtonDown, 2 = ButtonUp</param>
            /// <returns>Bool</returns>
            public static bool GetJoystickClick(int n, int j, int type) {
                string input = "Controller" + n + "_Joystick" + j + "_Click";
                switch (type) {
                    case 0: return Input.GetButton(input);
                    case 1: return Input.GetButtonDown(input);
                    case 2: return Input.GetButtonUp(input);
                }
                return false;
            }

            /// <summary>
            /// Obtener el axis del pad.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <returns>Vector2</returns>
            public static Vector2 GetPad(int n) {
                Vector2 axis = new Vector2(Input.GetAxis("Controller" + n + "_Pad_Horizontal"),
                                           Input.GetAxis("Controller" + n + "_Pad_Vertical"));
                if (axis != Vector2.zero) {
                    padMoved[n - 1] = true;
                }
                return axis;
            }

            /// <summary>
            /// Verifica si el pad regreso al centro despues de ser movido.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <returns>Bool</returns>
            public static bool PadReturnedCenter(int n) {
                if (padMoved[n - 1]) {
                    Vector2 axis = new Vector2(Input.GetAxis("Controller" + n + "_Pad_Horizontal"),
                                               Input.GetAxis("Controller" + n + "_Pad_Vertical"));
                    if (axis == Vector2.zero) {
                        padMoved[n - 1] = false;
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Valor de un trigger.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <param name="side">Letra del trigger: 1 = L, 2 = R</param>
            /// <returns>Float</returns>
            public static float GetTrigger(int n, int side) {
                float r = Input.GetAxis("Controller" + n + "_" + (side == 1 ? "L" : "R") + "T");
                if (r != 0) {
                    TriggerMoved[n - 1, side - 1] = true;
                }
                return r;
            }

            /// <summary>
            /// Verifica si un trigger fue levantado.
            /// </summary>
            /// <param name="n">Numero del control: 1 - 8</param>
            /// <param name="side">Letra del trigger: 1 = L, 2 = R</param>
            /// <returns>Bool</returns>
            public static bool TriggerUp(int n, int side) {
                if (TriggerMoved[n - 1, side - 1]) {
                    if (Input.GetAxis("Controller" + n + "_" + (side == 1 ? "L" : "R") + "T") == 0) {
                        TriggerMoved[n - 1, side - 1] = false;
                        return true;
                    }
                }
                return false;
            }
            
        }
    }
}