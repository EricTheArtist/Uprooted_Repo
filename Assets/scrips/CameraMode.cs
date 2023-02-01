using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    
    public camera_mode current_mode;

    public enum camera_mode
    {
        exploration,
        combat,
        topdown,
        cutscene
    }
  
}
