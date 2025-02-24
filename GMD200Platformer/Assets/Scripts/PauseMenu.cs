using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool paused;

    private RectTransform rt;

    public void Resume()
    {

        paused = false;

    }

    private void Awake()
    {

        paused = false;

        rt = GetComponent<RectTransform>();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            paused = true;

        }

        if (paused)
        {

            rt.anchoredPosition = new Vector2(-600, 0);

        }
        else if (!paused)
        {

            rt.anchoredPosition = new Vector2(-1800, 0);

        }

    }
}
