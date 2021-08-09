using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePersonaje2 : MonoBehaviour
{
    public GameObject llave;
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
            bool linterna = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerMovement>().haylinterna();
            if (Input.GetKey(KeyCode.Z))
            {
                llave.GetComponent<ApareceLLave>().CambiarFadeIn(!linterna);

            }
        }

    }
}
