using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    public GameObject yo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(1f);
        yo.SetActive(false);

    }
}
