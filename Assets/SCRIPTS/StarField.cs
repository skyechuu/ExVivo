using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour
{

    private Transform thisTransform;
    private ParticleSystem.Particle[] points;
    private float startDistanceSqr;
    private float starClipDistanceSqr;

    public Color startColor;
    public int starsMax = 600;
    public float startSize = .35f;
    public float starDistance = 60f;
    public float starClipDistance = 15f;


    // Use this for initialization
    void Start()
    {

        thisTransform = GetComponent<Transform>();
        startDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;

    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + thisTransform.position;
            points[i].color = new Color(startColor.r, startColor.g, startColor.b, startColor.a);
            points[i].size = startSize;
        }
    }

    void Update()
    {
        if (points == null)
            CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            if ((points [i].position - thisTransform.position).sqrMagnitude > startDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + thisTransform.position;
            }
            if ((points[i].position - thisTransform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percentage = (points[i].position - thisTransform.position).sqrMagnitude / starClipDistanceSqr;
                points[i].startColor = new Color(1, 1, 1, percentage);
                points[i].startSize = percentage * startSize;
            }
        }
        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }
}

