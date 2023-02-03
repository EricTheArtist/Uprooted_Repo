using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Transform damagePopup;
    [SerializeField] private Transform housePosition;
    [SerializeField] private int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        /*//referencing dama
        Transform damagePopupTransform = Instantiate(damagePopup, housePosition, Quaternion.identity);

        //calling set up function
        DamagePopup damagePopupClass = damagePopupTransform.transform.GetComponent<DamagePopup>();
        damagePopupClass.SetUp(damageAmount);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))//on Collision enter
        {
            Transform damagePopupTransform = Instantiate(damagePopup, housePosition.position, Quaternion.identity);
            //referenicing DamagePopup script/class to get SetUp func
            DamagePopup damagePopupClass = damagePopupTransform.transform.GetComponent<DamagePopup>();
            damagePopupClass.SetUp(damageAmount);
        }
    }
}
