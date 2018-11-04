using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheckSFXVolume : MonoBehaviour
{

    public AudioMixer MainMixer;

    public void SetSound(float soundLevel)
    {
        MainMixer.SetFloat("SFXVol", soundLevel);
    }
}