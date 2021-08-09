using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    private bool titila=false;
    public GameObject luz;
    public GameObject linterna;
    public GameObject[] decoracionesPared;
    public bool apagaluz;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject decoracion in decoracionesPared)
        {
            decoracion.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!titila && col.gameObject.tag == "Personaje")
        {
            StartCoroutine(waiter());
            titila = true;
        }

    }

    IEnumerator waiter()
    {

        

        float tiempo = 0.1F;

        int i = 0;
        while (i < 2)
        {
            luz.SetActive(true);
            linterna.SetActive(true);
            yield return new WaitForSeconds(tiempo);
            luz.SetActive(false);
            linterna.SetActive(false);
            yield return new WaitForSeconds(tiempo);

            linterna.SetActive(true);

            foreach (GameObject decoracion in decoracionesPared)
            {
                if (i == 0)
                {
                    decoracion.SetActive(true);
                }
                
            }

            yield return new WaitForSeconds(tiempo*10);
            luz.SetActive(false);
            linterna.SetActive(false);
            yield return new WaitForSeconds(tiempo);
            luz.SetActive(true);

            linterna.SetActive(true);
            yield return new WaitForSeconds(tiempo);
            luz.SetActive(false);
            linterna.SetActive(false);
            yield return new WaitForSeconds(tiempo);
            luz.SetActive(true);
            linterna.SetActive(true);

            yield return new WaitForSeconds(tiempo*10);
            i++;
        }
        if (apagaluz)
        {
            luz.SetActive(false);
        }
        

    }
}
