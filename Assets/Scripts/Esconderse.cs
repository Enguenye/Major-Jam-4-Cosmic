using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esconderse : MonoBehaviour
{
    public GameObject indicador;
    public GameObject personaje;
    bool estadesaparecido = false;
    bool enproceso = false;
    bool trigerexit = false;
    public GameObject luz;
    public GameObject enemigoDenso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (estadesaparecido)
            {
                StartCoroutine(Particulas2());
            }
        }
           
    }

    IEnumerator Particulas()
    {
        if (!enproceso)
        {
            enproceso = true;
            trigerexit = true;
            if (enemigoDenso.active)
            {
                enemigoDenso.GetComponent<FollowThePath>().quieto();
            }         
            luz.SetActive(true);
            luz.transform.position = transform.position;
            personaje.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            estadesaparecido = true;
            trigerexit = false;
            enproceso = false;
        }

    }

    IEnumerator Particulas2()
    {
        if (!enproceso)
        {
            luz.SetActive(false);
            enproceso = true;
            personaje.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            estadesaparecido = false;
            enproceso = false;
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            indicador.SetActive(true);
            if (Input.GetKey(KeyCode.X))
            {
                StartCoroutine(Particulas());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Personaje" &&!trigerexit)
        {
            indicador.SetActive(false);
        }
    }
}
