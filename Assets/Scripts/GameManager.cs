using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public GameObject player;
    private Vector3 m_OriginPos;
    public AudioSource audioData;
    public AudioSource audioData2;
    public AudioSource audioData3;
    public bool terminoDemo = false;
    public GameObject panel;
    public GameObject texto;
    public GameObject boton;
    string escena = "Start";

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            m_OriginPos = player.transform.position;
            if (!terminoDemo)
            {
                StartCoroutine(Restart());
            }
            else
            {
                StartCoroutine(EndDemo());
            }
            
        }
        
    }


    public void CambiarEscena(string nuevaEscena)
    {
        escena = nuevaEscena;
    }

    public void Termino()
    {
        terminoDemo = true;
    }

    public void agarrarLlave()
    {
        audioData2.Play(2);
    }

    IEnumerator EndDemo()
    {

        yield return new WaitForSeconds(1.3f);

        panel.SetActive(true);
        yield return new WaitForSeconds(2f);
        texto.SetActive(true);
        boton.SetActive(true);

    }

    IEnumerator Restart()
    {
        audioData.Play(3);
        audioData3.Play(3);
        player.GetComponent<Animator>().SetBool("muerto", true);
        yield return new WaitForSeconds(1.3f);
        player.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(escena);

    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            player.transform.position = m_OriginPos;
        }
    }
}
