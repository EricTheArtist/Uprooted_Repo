using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlotConstrustion : MonoBehaviour
{
    public Material CanPlaceMat;
    public Color CanPlace;
    public Color NotPlace;
    public bool ClearToPlace;

    public GameObject HouseAndBenchPrefab;
    public Script_UIManagement SUIM;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ClearToPlace == true)
        {
            Instantiate(HouseAndBenchPrefab);
            SUIM.SetWorkbenchRefrence();
            Destroy(gameObject);
        } 
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
