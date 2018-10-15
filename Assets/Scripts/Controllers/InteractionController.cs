using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {

    [SerializeField] LayerMask interactionLayers;
    [SerializeField] float interactionDistance;

    private Ray ray;
    private RaycastHit hit;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit, interactionDistance, interactionLayers))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
