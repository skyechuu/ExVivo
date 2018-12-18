using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
    public Transform receiver;

    private bool playerIsOverlapping = false;


    void Update()
    {
        Teleport();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    void Teleport()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = transform.position - player.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            if (dotProduct < 0f)
            {
                // Teleport !
                Debug.Log("Teleported!");

                float rotationDifference = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDifference += 180f;
                player.Rotate(Vector3.up, rotationDifference);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }





}
