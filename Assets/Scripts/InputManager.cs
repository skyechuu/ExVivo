using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Transform player;
    [Header("Settings")]
    [SerializeField] static float cameraXSensitivity = 350f;
    [SerializeField] static float cameraYSensitivity = 350f;

    private static vp_FPInput inputController;

    void Awake()
    {
        inputController = player.GetComponent<vp_FPInput>();
    }

    public static KeyCode InteractionKey
    {
        get {
            return KeyCode.E;
        }
    }

    public static float MouseX
    {
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

    void Update()
    {
    }

    public static void ActivateCursorMode()
    {
        inputController.MouseCursorForced = true;
        inputController.MouseCursorBlocksMouseLook = true;
    }

    public static void DeactivateCursorMode()
    {
        inputController.MouseCursorForced = false;
        inputController.MouseCursorBlocksMouseLook = false;
    }
}
