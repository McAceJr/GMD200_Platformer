using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signTextManager : MonoBehaviour
{
    
    public GameObject textObj;

    private void Awake()
    {
        
        textObj.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        textObj.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        textObj.SetActive(false);

    }

}
