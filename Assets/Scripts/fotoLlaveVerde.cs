using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fotoLlaveVerde : MonoBehaviour
{
    public GameObject cuadro;
    public GameObject indicador;
    public GameObject caja;
    bool activo = false;
    // Start is called before the first frame update
    void Start()
    {
        cuadro.SetActive(false);
        indicador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        cuadro.SetActive(false);
        indicador.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            if (Input.GetKey(KeyCode.X))
            {
                cuadro.SetActive(true);
                caja.GetComponent<CircleCollider2D>().enabled = true;
            }
            indicador.SetActive(true);
        }
            
    }
}
