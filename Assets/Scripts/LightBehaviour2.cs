using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour2 : MonoBehaviour
{
    public GameObject hitboxLinterna;
    public GameObject linterna;
    public GameObject[] enemigos;
    public GameObject[] velas;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject enemigo in enemigos)
        {
            enemigo.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Personaje")
        {
            linterna.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = new Color(0.5f, 0f, 0.03f, 1f); ;
            hitboxLinterna.SetActive(false);
            foreach (GameObject vela in velas)
            {
                if (vela != null)
                {
                    vela.SetActive(false);
                }

            }
            foreach (GameObject enemigo in enemigos)
            {
                if (enemigo != null)
                {
                    enemigo.SetActive(true);
                }

            }
        }
        

    }
}
