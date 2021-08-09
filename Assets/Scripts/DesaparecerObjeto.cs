using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerObjeto : MonoBehaviour
{
    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {

            if (Input.GetKey(KeyCode.X))
            {
                objeto.SetActive(false);
            }


        }

    }
}
