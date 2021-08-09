using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject personaje;
    public GameObject luz;
    public GameObject indicador;
    public GameObject enemigo;
    public AudioSource audioData;
    public GameObject linterna;
    bool termino = false;
    // Start is called before the first frame update
    void Start()
    {
        enemigo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            if (!termino)
            {
                indicador.SetActive(true);
            }
            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log(termino);
                if (!termino)
                {
                    luz.SetActive(true);
                    linterna.SetActive(false);
                    personaje.GetComponent<PlayerMovement>().enabled = false;
                    StartCoroutine(EndGame());
                }
                
            }


        }

    }

    IEnumerator EndGame()
    {
        FindObjectOfType<GameManager>().Termino();
        termino = true;
        indicador.SetActive(false);
        enemigo.SetActive(true);
        audioData.Play(2);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(1f);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(1f);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(1f);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(1f);
        luz.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        luz.SetActive(true);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().EndGame();

    }
}
