using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int wood_count, metal_count, brick_count, tire_count, wire_count;
    public GameObject current_item;
    public GameObject wood_prefab, metal_prefab, brick_prefab, tire_prefab, wire_prefab;

    private void Start()
    {
        wood_count = 0;
        metal_count = 0;
        brick_count = 0;
        tire_count = 0;
        wire_count = 0;
    }
    private void Update()
    {
        
    }

    public void add_item(GameObject item_to_add)
    {
        if (item_to_add.name == "Wood(Clone)")
        {
            wood_count++;
            current_item = wood_prefab;
        }
        if(item_to_add.name== "Metal(Clone)")
        {
            metal_count++;
            current_item = metal_prefab;
        }
        if (item_to_add.name == "Brick(Clone)")
        {
            brick_count++;
            current_item = brick_prefab;
        }
        if (item_to_add.name == "Tire(Clone)")
        {
            tire_count++;
            current_item = tire_prefab;
        }
        if (item_to_add.name == "Wire(Clone)")
        {
            wire_count++;
            current_item = metal_prefab;
        }

    }

    public void remove_item(GameObject item_to_remove)
    {
        if (current_item.name == "Wood")
        {
            wood_count--;
            current_item = null;
        }
        if (item_to_remove.name == "Metal")
        {
            metal_count--;
            current_item = null;

        }
        if (item_to_remove.name == "Brick")
        {
            brick_count--;
            current_item = null;

        }
        if (item_to_remove.name == "Tire")
        {
            tire_count--;
            current_item = null;

        }
        if (item_to_remove.name == "Wire")
        {
            wire_count--;
            current_item = null;

        }
    }
}
