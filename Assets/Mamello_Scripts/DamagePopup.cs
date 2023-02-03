using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopup : MonoBehaviour
{
    //creating popup
    /*  public static DamagePopup CreatePopup(Vector3 position, int damageAmount)
      {
          //referencing dama
          Transform damagePopupTransform = Instantiate(AssetReferencer.instance.damagePopup, position, Quaternion.identity);

          //calling set up function
          DamagePopup damagePopupClass = damagePopupTransform.transform.GetComponent<DamagePopup>();
          damagePopupClass.SetUp(damageAmount);

          return damagePopupClass;
      }*/

    public float disappearTimer;

    private TextMeshPro textMesh;
    private Color textColour;


    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();  
    }

    public void SetUp(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColour = textMesh.color;
        disappearTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //moving up over time 
        float moveSpeedY = 5f;
        transform.position += new Vector3(0, moveSpeedY) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            //reducing text colour's alpha 
            textColour.a -= disappearSpeed * Time.deltaTime;
            //applying low alpha colour to text mesh
            textMesh.color = textColour;
            if (textColour.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

   
}
