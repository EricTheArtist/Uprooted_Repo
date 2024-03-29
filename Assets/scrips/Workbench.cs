using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Workbench : MonoBehaviour
{
    public GameObject player_model;
    InventoryScript inventory;
    Script_UIManagement S_UIM;
    public HouseDamage PlayerHouseDamage;
    //WorkBench Storages
    public int wood_count, metal_count, brick_count, tire_count, wire_count;
    //WorkBench Upgrades Stats
    [Header("Upgrade Stats")]
    public GameObject house_parent;
    public GameObject House;
    public ParticleSystem UpgradeEffect;

    public int upgrade_phase = 1;
    public bool upgrade_range = false;
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
        player_model = GameObject.FindGameObjectWithTag("Player");
        upgrade_range = false;
        upgrade_phase = 1;
        required_upgrade_update();
        inventory = player_model.GetComponentInParent<InventoryScript>();
        S_UIM.UpdateResourcesUI();// initial setting of UI display values
    }

    public void SetUIManager(Script_UIManagement Ref)
    {
        S_UIM = Ref;
    }
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.U) && check_resources() && upgrade_range == true)
        {
            upgrade_house();
            UpgradeEffect.Play();
        }
    }
    //a button function used to call the upgrad function if the player can upgrade the house
    /*public void call_upgrade_house()
    {
        if (can_upgrade && upgrade_phase!=7)
        {
            upgrade_house();
        }
        else
        {
            return;
        }
    }*/
    //calls the add function 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player_model)
        {
            upgrade_range = true; //
            if (inventory.current_item != null)
            {
                add_item(inventory.current_item);
                inventory.remove_item(inventory.current_item);
            }
            S_UIM.UpdateResourcesUI(); //UpdateUI(); // refresh resouce display in UI
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player_model)
        {
            upgrade_range = false;
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

        S_UIM.UpdateResourcesUI(); //UpdateUI(); //refreshes UI to reflect new values
    }
    //updates the required ammounts based on the current house phase
    void required_upgrade_update()
    {
        Debug.Log("called on start");
        if (upgrade_phase == 1)
        {
            upgrade_wood_amount = 5;
            upgrade_brick_amount = 1;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 1;
        }
        if (upgrade_phase == 2)
        {
            upgrade_wood_amount = 6;
            upgrade_brick_amount = 2;
            upgrade_metal_amount = 4;
            upgrade_tire_amount = 1;
            upgrade_wire_amount = 2;
        }
        if (upgrade_phase == 3)
        {
            upgrade_wood_amount = 8;
            upgrade_brick_amount = 2;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 2;
            upgrade_wire_amount = 4;
        }
        if (upgrade_phase == 4)
        {
            upgrade_wood_amount = 10;
            upgrade_brick_amount = 10;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 5;
        }
        if (upgrade_phase == 5)
        {
            upgrade_wood_amount = 15;
            upgrade_brick_amount = 15;
            upgrade_metal_amount = 5;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 7;
        }
        if (upgrade_phase == 6)
        {
            upgrade_wood_amount = 20;
            upgrade_brick_amount = 20;
            upgrade_metal_amount = 10;
            upgrade_tire_amount = 0;
            upgrade_wire_amount = 10;
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
    public bool check_resources()
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
        house_parent.transform.GetChild(upgrade_phase).gameObject.SetActive(true);
        required_upgrade_update();
        HouseDamage HDmg = House.GetComponent<HouseDamage>(); //resets house HP to max
        HDmg.MaxHouseHealth();
    }
    //button function used to upgrade the house | changes phase and uses up resources
    void upgrade_house()
    {
        house_prefab_active();
        remove_item();
        upgrade_phase++;
        required_upgrade_update();
        S_UIM.UpdateResourcesUI(); //Update UI
        //change house prefab
        PlayerHouseDamage.enablehousedamge();

    }
    
}
