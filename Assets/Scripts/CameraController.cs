using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Camera playerCamera;
    [SerializeField] Transform target;

    [Header("Debug")]
    [SerializeField] Vector2 mouseAxis;
    

    void Update() {
        mouseAxis = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

    void LateUpdate() {
        RotateCamera();
        FollowTarget();
    }

    void RotateCamera()
    {
        var deltaX = InputManager.MouseX * Time.deltaTime;
        var deltaY = InputManager.MouseY * Time.deltaTime * -1;
        var deltaRotation = new Vector3(deltaY, deltaX, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + deltaRotation);
    }

    void FollowTarget()
    {
        transform.position = target.position;
    }
}
