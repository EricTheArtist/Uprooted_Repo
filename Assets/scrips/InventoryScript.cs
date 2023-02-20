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

    [Header("Inventory UI Icons")]
    public GameObject wood_icon;
    public GameObject brick_icon;
    public GameObject metal_icon;
    public GameObject tire_icon;
    public GameObject wire_icon;

    [Header("Inventory Carry Items")]
    public GameObject wood_Item;
    public GameObject brick_Item;
    public GameObject metal_Item;
    public GameObject tire_Item;
    public GameObject wire_Item;


    private void Start()
    {
        deactivate_icon();

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
            deactivate_icon();
            wood_icon.SetActive(true);
            wood_Item.SetActive(true);
        }
        if(item_to_add.name== metal_pickup_name+"(Clone)")
        {
            metal_count++;
            current_item = metal_prefab;
            deactivate_icon();
            metal_icon.SetActive(true);
            metal_Item.SetActive(true);

        }
        if (item_to_add.name == brick_pickup_name+"(Clone)")
        {
            brick_count++;
            current_item = brick_prefab;
            deactivate_icon();
            brick_icon.SetActive(true);
            brick_Item.SetActive(true);

        }
        if (item_to_add.name == tire_pickup_name+"(Clone)")
        {
            tire_count++;
            current_item = tire_prefab;
            deactivate_icon();
            tire_icon.SetActive(true);
            tire_Item.SetActive(true);

        }
        if (item_to_add.name == wire_pickup_name+"(Clone)")
        {
            wire_count++;
            current_item = wire_prefab;
            deactivate_icon();
            wire_icon.SetActive(true);
            wire_Item.SetActive(true);

        }

    }

    public void remove_item(GameObject item_to_remove)
    {
        if (current_item.name == wood_pickup_name)
        {
            wood_count--;
            deactivate_icon();
            current_item = null;
        }
        if (item_to_remove.name == metal_pickup_name)
        {
            metal_count--;
            deactivate_icon();
            current_item = null;

        }
        if (item_to_remove.name == brick_pickup_name)
        {
            brick_count--;
            deactivate_icon();
            current_item = null;

        }
        if (item_to_remove.name == tire_pickup_name)
        {
            tire_count--;
            deactivate_icon();
            current_item = null;

        }
        if (item_to_remove.name == wire_pickup_name)
        {
            wire_count--;
            deactivate_icon();
            current_item = null;

        }
    }
    //deactivates all icon gameobjects in the inventory ui
    void deactivate_icon()
    {
        wood_icon.SetActive(false);
        metal_icon.SetActive(false);
        brick_icon.SetActive(false);
        tire_icon.SetActive(false);
        wire_icon.SetActive(false);

        wood_Item.SetActive(false);
        metal_Item.SetActive(false);
        brick_Item.SetActive(false);
        tire_Item.SetActive(false);
        wire_Item.SetActive(false);

    }
}
