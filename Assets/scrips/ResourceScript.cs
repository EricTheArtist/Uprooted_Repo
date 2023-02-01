using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
   // public GameObject player;
    public int resource_health;
   /* public resource_type type;
    public enum resource_type
    {
        wood,
        metal,
        brick
    }*/

    public GameObject drop_prefab;
    public bool can_mine;


    public void mine_resource()
    {
       // Debug.Log("Mine Resource Called");
        if (resource_health <= 0)
        {
            //instantiate and play destroyed particle effect and sound
            //instantiate resource material 
            Instantiate(drop_prefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            //destroy game object
            Destroy(this.gameObject);
        }
        else
        {
             resource_health--;
        }
    }
  
}
