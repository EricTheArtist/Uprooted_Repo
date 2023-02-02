using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public GameObject player_model;
    InventoryScript inventory;

    //WorkBench Storages
    public int wood_count, metal_count, brick_count, tire_count, wire_count;
    //WorkBench Upgrades Stats
    [Header("Upgrade Stats")]
    public GameObject house_parent;
    public int upgrade_phase = 0;
    public bool can_upgrade = false;
    public int upgrade_wood_amount;
    public int upgrade_metal_amount;
    public int upgrade_brick_amount;
    public int upgrade_wire_amount;
    public int upgrade_tire_amount;

    [Header("Pick Up Names")]
    public string wood_pickup_name;
    public string metal_pickup_name;
    public string brick_pickup_name;
    public string tire_pickup_name;
    public string wire_pickup_name;

    private void Start()
    {
        can_upgrade = false;
        inventory = player_model.GetComponentInParent<InventoryScript>();
    }
    private void Update()
    {
        required_upgrade_update();
        if (check_resources())
        {
            can_upgrade = true;
        }
        else { can_upgrade = false; }
        //test case for house upgrade:
        //comment out after testing is complete
        if (Input.GetKeyUp(KeyCode.U))
        {
            upgrade_house();
        }
    }
    //a button function used to call the upgrad function if the player can upgrade the house
    public void call_upgrade_house()
    {
        if (can_upgrade && upgrade_phase!=7)
        {
            upgrade_house();
        }
        else
        {
            return;
        }
    }
    //calls the add function 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player_model)
        {
            if (inventory.current_item != null)
            {
                add_item(inventory.current_item);
                inventory.remove_item(inventory.current_item);
            }
            
        }
    }
    //add the resource to the work bench
    public void add_item(GameObject item_to_add)
    {
        if (item_to_add.name == wood_pickup_name)
        {
            wood_count++;
        }
        if (item_to_add.name == metal_pickup_name)
        {
            metal_count++;
        }
        if (item_to_add.name == brick_pickup_name)
        {
            brick_count++;
        }
        if (item_to_add.name == tire_pickup_name)
        {
            tire_count++;
        }
        if (item_to_add.name == wire_pickup_name)
        {
            wire_count++;
        }

    }
    //removes the resources required when upgrading
    public void remove_item()
    {
        wood_count -= upgrade_wood_amount;
        brick_count -= upgrade_brick_amount;
        metal_count -= upgrade_metal_amount;
        tire_count -= upgrade_tire_amount;
        wire_count -= upgrade_wire_amount;
    }
    //updates the required ammounts based on the current house phase
    void required_upgrade_update()
    {
        if (upgrade_phase == 1)
        {
            upgrade_wood_amount = 1;
            upgrade_brick_amount = 0;
            upgrade_metal_amount = 0;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 1;
        }
        if (upgrade_phase == 2)
        {
            upgrade_wood_amount = 5;
            upgrade_brick_amount = 1;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 1;
        }
        if (upgrade_phase == 3)
        {
            upgrade_wood_amount = 6;
            upgrade_brick_amount = 2;
            upgrade_metal_amount = 4;
            upgrade_tire_amount = 1;
            upgrade_wire_amount = 2;
        }
        if (upgrade_phase == 4)
        {
            upgrade_wood_amount = 8;
            upgrade_brick_amount = 2;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 2;
            upgrade_wire_amount = 4;
        }
        if (upgrade_phase == 5)
        {
            upgrade_wood_amount = 10;
            upgrade_brick_amount = 10;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 5;
        }
        if (upgrade_phase == 6)
        {
            upgrade_wood_amount = 15;
            upgrade_brick_amount = 15;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 7;
        }
        if (upgrade_phase == 7)
        {
            upgrade_wood_amount = 20;
            upgrade_brick_amount = 20;
            upgrade_metal_amount = 10;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 10;
        }

    }
    //checks if the required resources are enough to upgrade the house's current state
    bool check_resources()
    {
        bool upgrade = false;
        //check wood count
        if (wood_count >= upgrade_wood_amount && metal_count >= upgrade_metal_amount && brick_count >= upgrade_brick_amount && tire_count >= upgrade_tire_amount && wire_count >= upgrade_wire_amount)
        {
            upgrade = true;
        }
        else { upgrade = false; }
       
        Debug.Log(upgrade);
        return upgrade;
    }
    //sets the correct child active depending on the current phase
    void house_prefab_active()
    {
        //deactivates all children under the parent
        for (int i = 0; i < 7; i++)
        {
            Debug.Log(i);
            house_parent.transform.GetChild(i).gameObject.SetActive(false);
        }
        house_parent.transform.GetChild(upgrade_phase - 1).gameObject.SetActive(true);
    }
    //button function used to upgrade the house | changes phase and uses up resources
    void upgrade_house()
    {
        remove_item();
        upgrade_phase++;
        //change house prefab
        house_prefab_active();
    }
    
}
