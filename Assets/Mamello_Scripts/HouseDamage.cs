using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDamage : MonoBehaviour
{
    [SerializeField] private int houseHealth = 100;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private Transform damagePopup;
    [SerializeField] private Transform housePosition;
   

    // Start is called before the first frame update
    void Start()
    {
        housePosition = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (houseHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RedAnt")
        {
            houseHealth -= damageAmount;
            Transform damagePopupTransform = Instantiate(damagePopup, housePosition.position, Quaternion.identity);
            //referenicing DamagePopup script/class to get SetUp func
            DamagePopup damagePopupClass = damagePopupTransform.transform.GetComponent<DamagePopup>();
            damagePopupClass.SetUp(houseHealth);
        }
    }
}
