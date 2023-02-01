using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickUp : MonoBehaviour
{
    public GameObject player;

    InventoryScript inventory;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponentInParent<InventoryScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== player && inventory.current_item==null)
        {
            Debug.Log("Player Picked up" + this.gameObject.name);
            inventory.add_item(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
