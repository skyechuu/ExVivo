using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordController : MonoBehaviour {

    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRecording(AudioClip recording)
    {
        source.Stop();
        source.PlayOneShot(recording);
    }

	
}
