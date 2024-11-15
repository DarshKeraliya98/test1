using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dilivery : MonoBehaviour
{
    // void OnCollisionEnter2D(Collision2D other) 
    // {
    //     Debug.Log("Bump Ahed");    
    // }

    [SerializeField] float delayTime = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Collected");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,delayTime);
        }

        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Customer Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
