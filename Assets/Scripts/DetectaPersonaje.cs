using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPersonaje : MonoBehaviour
{
    public GameObject llave;
    float timeLeft = 5f;
    public AudioSource audioData;
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
            timeLeft -= Time.deltaTime;
            Debug.Log(linterna);
            if (!linterna)
            {
                if (timeLeft < 0)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
                
            }
            else if (linterna)
            {
                audioData.Play(2);
                timeLeft = 5f;
            }
        }

    }
}
