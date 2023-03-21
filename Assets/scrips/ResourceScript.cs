using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
  
    public int resource_health;


    public GameObject drop_prefab;
    public bool can_mine;

    public int ItemsDropped = 1;
    public float ItemSpread = 1;

    public void mine_resource()
    {
       
        if (resource_health <= 0)
        {

            //instantiate and play destroyed particle effect and sound
            //instantiate resource material 

            for (int i = 0; i < ItemsDropped; i++)
            {
          
                Random.Range(0,ItemSpread);

                //spawns each drop with a randomised spread
                GameObject preab =Instantiate(drop_prefab, new Vector3(transform.position.x + Random.Range(-ItemSpread, ItemSpread), 
                                                    transform.position.y + Random.Range(0.5f, 1.1f),
                                                    transform.position.z + Random.Range(-ItemSpread, ItemSpread)),
                                                    Quaternion.identity);
                preab.transform.rotation = Quaternion.Euler(0, Random.Range(0,360),0);
            }

            //destroy game object
            Destroy(this.gameObject);
        }
        else
        {
             resource_health--;
        }
    }
  
}
