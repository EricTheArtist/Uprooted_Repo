using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManagement : MonoBehaviour
{
    public GameObject WorkBenchREF;
    Workbench WB;

    public GameObject ConfirmLocationprompt;
    public GameObject UpgradeHousePrompt;

    [Header("Resources")]
    public TextMeshProUGUI T_WoodStorage;
    public TextMeshProUGUI T_MetalStorage;
    public TextMeshProUGUI T_BrickStorage;
    public TextMeshProUGUI T_TireStorage;
    public TextMeshProUGUI T_WireStorage;

    public GameObject WoodBar;
    public GameObject MetalBar;
    public GameObject BrickBar;
    public GameObject TireBar;
    public GameObject WireBar;



    public void toggleConfirmLocationPrompt()
    {
        if (ConfirmLocationprompt.activeInHierarchy)
        {
            ConfirmLocationprompt.SetActive(false);
        }
        else
        {
            ConfirmLocationprompt.SetActive(true);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetWorkbenchRefrence()
    {
        WorkBenchREF = GameObject.Find("WorkBench");
        WB = WorkBenchREF.GetComponent<Workbench>();
        WB.SetUIManager(this);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateResourcesUI()
    {
        bool CR = WB.check_resources();
        if (CR == true)
        {
            UpgradeHousePrompt.SetActive(true);
        }
        else
        {
            UpgradeHousePrompt.SetActive(false);
        }

        T_WoodStorage.text = WB.wood_count.ToString() + "/" + WB.upgrade_wood_amount.ToString();
        T_MetalStorage.text = WB.metal_count.ToString() + "/" + WB.upgrade_metal_amount.ToString();
        T_BrickStorage.text = WB.brick_count.ToString() + "/" + WB.upgrade_brick_amount.ToString();
        T_TireStorage.text = WB.tire_count.ToString() + "/" + WB.upgrade_tire_amount.ToString();
        T_WireStorage.text = WB.wire_count.ToString() + "/" + WB.upgrade_wire_amount.ToString();

        if(WB.upgrade_wood_amount!= 0)
        {
            float scale = ((float)WB.wood_count / (float)WB.upgrade_wood_amount);
            if(scale <= 1)
            {
                WoodBar.transform.localScale = new Vector3(scale, 1, 1);
            }
            
        }
        if (WB.upgrade_metal_amount != 0)
        {
            float scale = ((float)WB.metal_count / (float)WB.upgrade_metal_amount);
            if(scale <= 1)
            {
                MetalBar.transform.localScale = new Vector3(scale, 1, 1);
            }
            
        }
        if (WB.upgrade_brick_amount != 0)
        {
            float scale = ((float)WB.brick_count / (float)WB.upgrade_brick_amount);
            if (scale <= 1)
            {
                BrickBar.transform.localScale = new Vector3(scale, 1, 1);
            }
            
        }
        if (WB.upgrade_tire_amount != 0)
        {
            float scale = ((float)WB.tire_count / (float)WB.upgrade_tire_amount);
            if (scale <= 1)
            {
                TireBar.transform.localScale = new Vector3(scale, 1, 1);
            }
            
        }
        if (WB.upgrade_wire_amount != 0)
        {
            float scale = ((float)WB.wire_count / (float)WB.upgrade_wire_amount);
            if (scale <= 1)
            {
                WireBar.transform.localScale = new Vector3(scale, 1, 1);
            }
            
        }
        
        
        
    }


}
