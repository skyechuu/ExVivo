using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InteractionController : MonoBehaviour {

    [SerializeField] LayerMask interactionLayers;
    [SerializeField] float interactionDistance;
    [SerializeField] Text interactionInformationText;

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
        Raycast();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(ray.origin, ray.direction*interactionDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hit.point, 0.5f);
    }

    void Raycast()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayers))
        {
            
            if (hit.transform.GetComponent<Pickupable>() != null)
            {
                interactionInformationText.text = hit.transform.GetComponent<Pickupable>().GetInteractionText();
                interactionInformationText.DOFade(0.8f, 0.2f);
                if (Input.GetKeyDown(InputManager.InteractionKey))
                    hit.transform.GetComponent<Pickupable>().PickupItem();
            }
        }
        else
        {
            interactionInformationText.DOFade(0, 0.2f);
        }
    }
}
