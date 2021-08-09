using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{
    public GameObject objetivo;
    public GameObject personaje;
    public GameObject indicador;
    public GameObject puerta;
    public bool tp = true;
    bool enproceso;
    bool enprocesoboss;
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        enproceso = false;
        enprocesoboss = false;
        indicador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Order()
    {
        if (!enproceso)
        {
            enproceso = true;
            personaje.transform.position = objetivo.transform.position;
            objetivo.GetComponent<Tp>().cambiarTp();
            yield return new WaitForSeconds(0.3f);
            enproceso = false;
        }

    }

    IEnumerator Order3()
    {
        if (!enprocesoboss)
        {
            boss = GameObject.FindWithTag("Boss");
            enprocesoboss = true;
            yield return new WaitForSeconds(4f);
            boss.transform.position = objetivo.transform.position;
            objetivo.GetComponent<Tp>().cambiarTp2();
            yield return new WaitForSeconds(8f);
            enprocesoboss = false;
        }

    }

    IEnumerator Order2()
    {
            enproceso = true;
            yield return new WaitForSeconds(0.3f);
            enproceso = false;

    }

    IEnumerator Order4()
    {
        enprocesoboss = true;
        yield return new WaitForSeconds(4f);
        enprocesoboss = false;

    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje" )
        {
            indicador.SetActive(true);
            if (Input.GetKey(KeyCode.X))
            {
                puerta.SetActive(false);
                StartCoroutine(Order());
            }
            

        }
        

    }

    public void cambiarTp()
    {
        StartCoroutine(Order2());
    }

    public void cambiarTp2()
    {
        StartCoroutine(Order4());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Personaje")
        {
            indicador.SetActive(false);
            tp = true;
        }
            
    }
}
