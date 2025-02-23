using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fliplines : MonoBehaviour
{

    public PlayerController Pc;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
            Pc.Flip();

    }

}
