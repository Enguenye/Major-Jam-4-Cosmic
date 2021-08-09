using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AgarrarLlave : MonoBehaviour
{

    public GameObject tp;
    public GameObject llave;
    public GameObject indicador;
    public GameObject llaveGrande;
    public GameObject cerrado;
    public GameObject llavemenu;
    public Sprite mySprite;

    // Start is called before the first frame update
    void Start()
    {
        llaveGrande.SetActive(false);
        llavemenu.SetActive(false);
        cerrado.SetActive(true);
        tp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            
            indicador.SetActive(true);
            if (Input.GetKey(KeyCode.X))
            {
                FindObjectOfType<GameManager>().agarrarLlave();
                tp.SetActive(true);
                llavemenu.SetActive(true);
                llavemenu.GetComponent<Image>().sprite = mySprite;
                llaveGrande.GetComponent<Image>().sprite = mySprite;
                llaveGrande.SetActive(true);
                cerrado.SetActive(false);
                llave.SetActive(false);
                indicador.SetActive(false);
            }
            
            
        }
        
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Personaje")
        {
            indicador.SetActive(false);
        }
    }
}
