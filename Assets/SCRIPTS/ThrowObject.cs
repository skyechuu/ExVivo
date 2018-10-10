using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip soundToPlay;
    public AudioClip soundToPlay2;
    public float Volume;
    private AudioSource audio;
    public int dmg;
    private bool touched = false;
    public bool alreadyPlayed = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnMouseOver()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 3f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetButton("Use"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
            RandomAudio();
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetButtonUp("Use"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                RandomAudio2();
               
            }
            else if (Input.GetButtonUp("Use"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                RandomAudio2();
            }
        }
    }
    void RandomAudio()
    {
        {
            if (!alreadyPlayed)
            {
                audio.PlayOneShot(soundToPlay, Volume);
                alreadyPlayed = true;
            }
        }

    }

    void RandomAudio2()
    {
        {
            if (alreadyPlayed)
            {
                audio.PlayOneShot(soundToPlay2, Volume);
                alreadyPlayed = false;
            }
        }

    }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}