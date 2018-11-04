using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpot : MonoBehaviour { 

   public float speed = 50.0f;

    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.up * speed * Time.deltaTime);


    }
}