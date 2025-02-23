using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{

    public string scene;

    public void Teleport()
    {

        SceneManager.LoadScene(scene);

    }

}
