using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int wood_count, metal_count, brick_count, tire_count, wire_count;
    public GameObject current_item;
    public GameObject wood_prefab, metal_prefab, brick_prefab, tire_prefab, wire_prefab;

    public string wood_pickup_name;
    public string metal_pickup_name;
    public string brick_pickup_name;
    public string tire_pickup_name;
    public string wire_pickup_name;
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
        if (item_to_add.name == wood_pickup_name+"(Clone)")
        {
            wood_count++;
            current_item = wood_prefab;
        }
        if(item_to_add.name== metal_pickup_name+"(Clone)")
        {
            metal_count++;
            current_item = metal_prefab;
        }
        if (item_to_add.name == brick_pickup_name+"(Clone)")
        {
            brick_count++;
            current_item = brick_prefab;
        }
        if (item_to_add.name == tire_pickup_name+"(Clone)")
        {
            tire_count++;
            current_item = tire_prefab;
        }
        if (item_to_add.name == wire_pickup_name+"(Clone)")
        {
            wire_count++;
            current_item = wire_prefab;
        }

    }

    public void remove_item(GameObject item_to_remove)
    {
        if (current_item.name == wood_pickup_name)
        {
            wood_count--;
            current_item = null;
        }
        if (item_to_remove.name == metal_pickup_name)
        {
            metal_count--;
            current_item = null;

        }
        if (item_to_remove.name == brick_pickup_name)
        {
            brick_count--;
            current_item = null;

        }
        if (item_to_remove.name == tire_pickup_name)
        {
            tire_count--;
            current_item = null;

        }
        if (item_to_remove.name == wire_pickup_name)
        {
            wire_count--;
            current_item = null;

        }
    }
}
