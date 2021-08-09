using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FollowThePath : MonoBehaviour
{

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    public GameObject personaje;
    public float radius;
    public float speed;
    bool boolQuieto=false;
    public Vector3 posicionInicial;
    public AudioSource audioData;
    bool sonido = true;
    public Animator animator;
    bool entro = false;


    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

        // Move Enemy
        Move();
    }

    public void quieto()
    {
        StartCoroutine(Particulas());
    }

    IEnumerator Particulas()
    {
        posicionInicial = transform.position;
        boolQuieto = true;
        yield return new WaitForSeconds(2f);
        boolQuieto = false;
    }

    IEnumerator Animacion()
    {
        if (!entro)
        {
            entro = true;
            animator.SetBool("ataca", true);
            yield return new WaitForSeconds(0.6f);
            animator.SetBool("loop", true);
        }
        
        boolQuieto = false;
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        float distanciagiro = 0;
        if (boolQuieto)
        {
            transform.position = posicionInicial;
        }
        float dist = Vector3.Distance(personaje.transform.position, transform.position);
        if(personaje.active&&dist < radius)
        {
            StartCoroutine(Animacion());
            if (sonido)
            {
                audioData.Play(2);
                sonido = false;
            }
            Vector3 target = personaje.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            distanciagiro = transform.position.x - target.x;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }
        else
        {
            if (!sonido)
            {
                audioData.Stop();
                sonido = true;
            }
            animator.SetBool("ataca", false);
            animator.SetBool("loop", false);
            entro = false;
            if (waypointIndex <= waypoints.Length - 1)
            {
                distanciagiro = transform.position.x - waypoints[waypointIndex].transform.position.x;
                // Move Enemy from current waypoint to the next one
                // using MoveTowards method
                transform.position = Vector3.MoveTowards(transform.position,
                   waypoints[waypointIndex].transform.position,
                   moveSpeed * Time.deltaTime);

                // If Enemy reaches position of waypoint he walked towards
                // then waypointIndex is increased by 1
                // and Enemy starts to walk to the next waypoint
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            }
            else
            {
                waypointIndex = 0;
                Transform[] tempArray = new Transform[waypoints.Length];
                for (int i = 0; i < waypoints.Length; i++)
                {
                    tempArray[waypoints.Length - 1 - i] = waypoints[i];
                }
                waypoints = tempArray;
            }
        }

        if (distanciagiro > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Personaje")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

