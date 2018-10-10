using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Audio;

public class GroundBehavior : MonoBehaviour
{

    public List<GroundType> GroundTypes = new List<GroundType>();
    public FirstPersonController FPC;
    public string currentground;

    // Use this for initialization
    void Start()
    {

        setGroundType(GroundTypes [0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Metal")
            setGroundType(GroundTypes[1]);
        else if (hit.transform.tag == "Grass")
            setGroundType(GroundTypes[2]);
        else
            setGroundType(GroundTypes[0]);

    }

    public void setGroundType(GroundType ground)
    {
        if (currentground != ground.name)
        {
            FPC.m_FootstepSounds = ground.footstepsounds;
            FPC.m_WalkSpeed = ground.walkSpeed;
            FPC.m_RunSpeed = ground.runSpeed;
            currentground = ground.name;
        }
    }
}

[System.Serializable]
public class GroundType
{
    
    public string name;
    public AudioClip[] footstepsounds;

    public float walkSpeed = 5;
    public float runSpeed = 10;
}

