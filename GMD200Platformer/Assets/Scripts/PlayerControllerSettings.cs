using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Player Settings")]

public class PlayerSettings : ScriptableObject
{

    public int moveSpeed;
    
    
    public LayerMask groundLayer;
    /*public LayerMask deathLayer;*/

    
    public float fallClamp;

}
