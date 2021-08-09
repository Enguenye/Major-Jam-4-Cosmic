﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerCosas : MonoBehaviour
{
    public GameObject[] decoracionesPared;
    private bool titila = false;
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
        if (col.gameObject.tag == "Personaje")
        {
            foreach (GameObject decoracion in decoracionesPared)
            {
                decoracion.SetActive(true);

            }
        }

    }

}
