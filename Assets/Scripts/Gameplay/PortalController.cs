using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour {

    public Transform playerCamera;
    public Transform worldSyncA;
    public Transform worldSyncB;
    public Camera portalCamera;

    public PortalRender portalRender;


    bool peaking = false;
    bool teleporting = false;
    bool render = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Teleport();
            //SwapWorldSyncPoints();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!peaking)
            {
                render = true;
                portalRender.PeakPortal(() =>
                {
                    peaking = true;
                });
            }
            else
            {
                teleporting = true;
                peaking = false;
                portalRender.OpenPortal(() =>
                {
                    Teleport(); 
                    print("Portal opened.");
                    //render = false;
                    //SwapWorldSyncPoints();
                    teleporting = false;
                });
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (peaking)
            {
                portalRender.CancelPeakPortal(() =>
                {
                    peaking = false;
                });
                
            }
        }
    }
    void LateUpdate()
    {
        RenderCamera();
    }

    void RenderCamera()
    {
        if (render)
        {
            Vector3 positionOffset = playerCamera.position - worldSyncB.position;
            portalCamera.transform.position = worldSyncA.position + positionOffset;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(worldSyncA.rotation, worldSyncB.rotation);
            Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
            portalCamera.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }

    void Teleport()
    {
        Vector3 positionOffset = transform.position - worldSyncB.position;
        Vector3 teleportPosition = worldSyncA.position + positionOffset;
        transform.position = teleportPosition;
        OnTeleportComplete();
    }

    void OnTeleportComplete()
    {
        SwapWorldSyncPoints();
        portalRender.OnTeleportComplete(() =>
        {
            //StartCoroutine(RequestSwapWorldSyncPoints());
        });
    }

    IEnumerator RequestSwapWorldSyncPoints()
    {
        yield return new WaitForEndOfFrame();
        SwapWorldSyncPoints();
    }

    void SwapWorldSyncPoints()
    {
        render = false;
        Transform temp = worldSyncA;
        worldSyncA = worldSyncB;
        worldSyncB = temp;
        render = true;
    }
}
