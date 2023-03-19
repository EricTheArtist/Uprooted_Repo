using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlotConstrustion : MonoBehaviour
{
    public Material CanPlaceMat;
    public Color CanPlace;
    public Color NotPlace;
    public bool ClearToPlace = true;

    public GameObject HouseAndBenchPrefab;
    public Script_UIManagement SUIM;
    GameObject House;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ClearToPlace == true)
        {
            House = Instantiate(HouseAndBenchPrefab); //spawns house and workbench
            House.transform.position = this.transform.position; //sents the homestead loaction to this location 
            SUIM.SetWorkbenchRefrence(); // tells UI to find the workbench we spawned
            SUIM.toggleConfirmLocationPrompt(); //turns of placement propmt
            Destroy(gameObject);
        } 
    }


    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("iscolliding: "+ other.ToString());
        if(other.tag != "Player")
        {
            CanPlaceMat.SetColor("_Color",NotPlace);
            ClearToPlace = false;
        } 
    }


    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("nocollision");
        if (other.tag != "Player")
        {
            CanPlaceMat.SetColor("_Color", CanPlace);
            ClearToPlace = true;
        }
    }
}
