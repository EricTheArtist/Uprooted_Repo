using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningScript : MonoBehaviour
{
    public GameObject weapon;
    public bool can_hit = true;
    public float cool_down = 0.1f;

    public LayerMask resource_layer;
    public GameObject raycast_holder;

    public GameObject temp_resource_holder;
    public GameObject interact_UI;

    private void Start()
    {
        interact_UI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (can_hit)
            {
                mine_hit();
            }
        }
    }
    private void FixedUpdate()
    {
        //this ray cast detects wether or not there is a resource located in front of the player
        RaycastHit hit;
        if (Physics.Raycast(raycast_holder.transform.position, Vector3.down, out hit, 10f, resource_layer))
        {
            Debug.DrawRay(raycast_holder.transform.position, Vector3.down * 10f, Color.blue);
            // Debug.Log("Can Hit Resource");
            interact_UI.SetActive(true);
            temp_resource_holder = hit.collider.gameObject;
            Debug.Log(temp_resource_holder);
        }
        else
        {
            Debug.DrawRay(raycast_holder.transform.position, Vector3.down * 10f, Color.red);
            //Debug.Log("Can Not Hit Resource");
            interact_UI.SetActive(false);
            temp_resource_holder = null;

        }

    }
    // allows the player to perform a hit action 
    public void mine_hit()
    {
        can_hit = false;
        //plays the hit animation
        Animator anim = weapon.GetComponent<Animator>();
        anim.SetTrigger("Hit");
        //calls a function to reset the hit cooldown
        StartCoroutine(reset_hit_cooldown());
        //if the player detects a resource in front of them, this will call the "Resource Script" attached to that resource
        if (temp_resource_holder != null)
        {
            ResourceScript resource_handler;
            resource_handler = temp_resource_holder.GetComponent<ResourceScript>();
           // Debug.Log("hitting object");
            //When the resource is hit:
            //Play Particle effect
            //call funtion from attached script to decrease health until destroyed
            resource_handler.mine_resource();
        }

    }

    IEnumerator reset_hit_cooldown()
    {
        yield return new WaitForSeconds(cool_down);
        can_hit = true;
    }

}
