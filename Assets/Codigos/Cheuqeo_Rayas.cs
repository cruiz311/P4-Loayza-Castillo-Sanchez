using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cheuqeo_Rayas : MonoBehaviour
{
    private int Count;

    void Update()
    {
        Chequeo();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("posicionPlayer"))
        {
            Count += 1;
        }

        if (col.CompareTag("Error"))
        {
            Count -= 1;
        }
    }


    //public void Mensagge()
    //{
    //    string correo = Count.ToString();
    //    Debug.Log(correo);
    //}

    void Chequeo()
    {
        if (Count < 3)
        {
            gameObject.SetActive(false);
        }
    }
}
