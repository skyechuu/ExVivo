using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera portalCamera;
    public Material portalCameraMaterial;

    void Start()
    {
        if(portalCamera.targetTexture != null)
        {
            portalCamera.targetTexture.Release();
        }
        portalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        portalCameraMaterial.mainTexture = portalCamera.targetTexture;
    }

}
