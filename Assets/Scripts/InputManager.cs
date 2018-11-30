using UnityEngine;

public class InputManager : MonoBehaviour {


    [Header("Settings")]
    [SerializeField] static float cameraXSensitivity = 350f;
    [SerializeField] static float cameraYSensitivity = 350f;

    public static float MouseX {
        get {
            return Input.GetAxis("Mouse X") * cameraXSensitivity;
        }
    }
    public static float MouseY
    {
        get {
            return Input.GetAxis("Mouse Y") * cameraYSensitivity;
        }
    }
    public static float KeyboardX
    {
        get {
            return Input.GetAxis("Horizontal");
        }
    }
    public static float KeyboardY
    {
        get {
            return Input.GetAxis("Vertical");
        }
    }

    void Update () {
		
	}
}
