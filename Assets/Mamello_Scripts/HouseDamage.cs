using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDamage : MonoBehaviour
{
    [SerializeField] private float houseHealth = 100;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private Transform damagePopup;
    [SerializeField] private Transform housePosition;

    public bool PlayerHouse = false;
    public GameObject HPBar;
    public float starthealth;

    // Start is called before the first frame update
    void Start()
    {
        housePosition = gameObject.GetComponent<Transform>();
        starthealth = houseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (houseHealth <= 0)
        {
            
            if (PlayerHouse == true)
            {
                SceneManager.LoadScene(3);
            }
            
            Destroy(gameObject);

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
            damagePopupClass.SetUp(damageAmount);
            if (PlayerHouse == true)
            {
                UpdateHPBar();
            }
        }

    }

    public void MaxHouseHealth()
    {
        houseHealth = starthealth;
        UpdateHPBar();

    }

    void UpdateHPBar()
    {
        HPBar = GameObject.FindGameObjectWithTag("HPBAR");
        HPBar.transform.localScale = new Vector3(houseHealth/starthealth, 1, 1);
    }
}
