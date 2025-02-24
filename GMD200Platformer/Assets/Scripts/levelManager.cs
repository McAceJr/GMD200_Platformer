using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{

    public GameObject[] levels;
    public GameObject[] doors;

    private bool Section1 = false;

    private void Awake()
    {
        
        if (PlayerController.levelComplete[0] &&
            PlayerController.levelComplete[1] &&
            PlayerController.levelComplete[2] &&
            PlayerController.levelComplete[3])
        {

            Section1 = true;

        }

        for (int i = 0; i < 4; i++)
        {

            if(PlayerController.levelComplete[i])
            {

                SpriteRenderer sr = levels[i].GetComponent<SpriteRenderer>();

                sr.color = new Color(0.5f, 0.5f, 0.5f);

            }

        }

        if (Section1)
        {

            doors[0].SetActive(false);

        }

        

    }

}
