using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlotConstrustion : MonoBehaviour
{
    public Material CanPlaceMat;
    public Color CanPlace;
    public Color NotPlace;
    public bool ClearToPlace;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag != "Player")
        {
            CanPlaceMat.SetColor("_Color",NotPlace);
            ClearToPlace = false;
        } 
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            CanPlaceMat.SetColor("_Color", CanPlace);
            ClearToPlace = true;
        }
    }
}
