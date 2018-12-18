using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PortalController : MonoBehaviour {

    public Transform playerCamera;
    public Transform worldSyncA;
    public Transform worldSyncB;
    public Camera portalCamera;
    public CanvasGroup portalFlash;
    public PortalRender portalRender;


    bool peaking = false;
    bool teleporting = false;
    bool render = false;

    void Update()
    {
        // Debug purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Teleport();
            //SwapWorldSyncPoints();
            //RenderPortalFlash();
        }

        if (Input.GetMouseButtonDown(1))
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
                RenderPortalFlash();
                portalRender.OpenPortal(() =>
                {
                    Teleport(); 
                    print("Portal opened.");
                    teleporting = false;
                });
            }
        }

        if (Input.GetMouseButtonDown(0))
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

    void RenderPortalFlash()
    {
        portalFlash.DOFade(1.5f, 0.5f).OnComplete(()=>
        {
            portalFlash.DOFade(0, 1f);
        });
    }
}
