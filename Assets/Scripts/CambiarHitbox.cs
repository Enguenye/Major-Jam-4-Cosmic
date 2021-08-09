using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarHitbox : MonoBehaviour
{
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            personaje.GetComponent<CapsuleCollider2D>().enabled = false;
            personaje.GetComponent<CircleCollider2D>().enabled = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {

            personaje.GetComponent<CapsuleCollider2D>().enabled = true;
            personaje.GetComponent<CircleCollider2D>().enabled = false;


        }

    }
}
