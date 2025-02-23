using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Parallax : MonoBehaviour
{

    //This Script is inspired from another parallax script that only parallaxes the X cords

    // https://medium.com/@Code_With_K/parallax-background-in-unity-fd8766d5a9bd

    private float startposX, startposY;
    public GameObject cam;
    public float parallaxMulti;

    private void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
    }

    private void Update()
    {

        float tempX = (cam.transform.position.x * (1 - parallaxMulti));
        float tempY = (cam.transform.position.y * (1 - parallaxMulti));
        float distX = (cam.transform.position.x * parallaxMulti);
        float distY = (cam.transform.position.y * parallaxMulti);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
    }

}
