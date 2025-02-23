using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public GameObject platform;
    public Transform pointA;
    public Transform pointB;
    public float speed;

    private bool atPointB;

    private void Start()
    {

        platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointA.position, 10000000f);

    }

    private void Update()
    {
        
        if (platform.transform.position == pointA.transform.position)
        {

            atPointB = false;

        }
        else if (platform.transform.position == pointB.transform.position)
        {

            atPointB = true;

        }

    }

    private void FixedUpdate()
    {

        if (atPointB)
        {

            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointA.position, speed * Time.deltaTime);

        }
        else if (!atPointB)
        {

            platform.transform.position = Vector3.MoveTowards(platform.transform.position, pointB.position, speed * Time.deltaTime);

        }

    }

}
