using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxLinterna : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Vector2 movementDirection = new Vector2(h, v);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        bool linterna = personaje.GetComponent<PlayerMovement>().haylinterna();
        if (linterna && col.gameObject.tag == "Mano")
        {
            ComportamientoEnemigo enemy = col.GetComponent<ComportamientoEnemigo>();
            enemy.Morir();
        }
        
    }
}
