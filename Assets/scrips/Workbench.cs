using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public GameObject player_model;
    InventoryScript inventory;

    //WorkBench Storages
    public int wood_count, metal_count, brick_count, tire_count, wire_count;
    //WorkBench Upgrades
    public int upgrade_wood_amount;
    public int upgrade_metal_amount;
    public int upgrade_brick_amount;
    public int upgrade_wire_amount;
    public int upgrade_tire_amount;

    private void Start()
    {
        inventory = player_model.GetComponentInParent<InventoryScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player_model)
        {
            add_item(inventory.current_item);
            inventory.remove_item(inventory.current_item);
        }
    }
    public void add_item(GameObject item_to_add)
    {
        if (item_to_add.name == "Wood")
        {
            wood_count++;
        }
        if (item_to_add.name == "Metal")
        {
            metal_count++;
        }
        if (item_to_add.name == "Brick")
        {
            brick_count++;
        }
        if (item_to_add.name == "Tire")
        {
            tire_count++;
        }
        if (item_to_add.name == "Wire")
        {
            wire_count++;
        }

    }

    public void remove_item(GameObject item_to_remove)
    {
        if (item_to_remove.name == "Wood(Clone)")
        {
            wood_count--;
        }
        if (item_to_remove.name == "Metal(Clone)")
        {
            metal_count--;
        }
        if (item_to_remove.name == "Brick(Clone)")
        {
            brick_count--;
        }
        if (item_to_remove.name == "Tire(Clone)")
        {
            tire_count--;
        }
        if (item_to_remove.name == "Wire(Clone)")
        {
            wire_count--;
        }
    }
}
