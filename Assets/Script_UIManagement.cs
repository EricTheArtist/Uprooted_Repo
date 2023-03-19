using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManagement : MonoBehaviour
{
    public GameObject WorkBenchREF;
    Workbench WB;

    [Header("Resources")]
    public TextMeshProUGUI T_WoodStorage;
    public TextMeshProUGUI T_MetalStorage;
    public TextMeshProUGUI T_BrickStorage;
    public TextMeshProUGUI T_TireStorage;
    public TextMeshProUGUI T_WireStorage;

    public TextMeshProUGUI T_WoodUpgrade;
    public TextMeshProUGUI T_MetalUpgrade;
    public TextMeshProUGUI T_BrickUpgrade;
    public TextMeshProUGUI T_TireUpgrade;
    public TextMeshProUGUI T_WireUpgrade;

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
        T_WoodStorage.text = WB.wood_count.ToString();
        T_MetalStorage.text = WB.metal_count.ToString();
        T_BrickStorage.text = WB.brick_count.ToString();
        T_TireStorage.text = WB.tire_count.ToString();
        T_WireStorage.text = WB.wire_count.ToString();

        T_WoodUpgrade.text = WB.upgrade_wood_amount.ToString();
        T_MetalUpgrade.text = WB.upgrade_metal_amount.ToString();
        T_BrickUpgrade.text = WB.upgrade_brick_amount.ToString();
        T_TireUpgrade.text = WB.upgrade_tire_amount.ToString();
        T_WireUpgrade.text = WB.upgrade_wire_amount.ToString();
    }


}
