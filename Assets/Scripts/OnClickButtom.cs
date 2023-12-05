using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickButtom : MonoBehaviour
{

    public static int contador;
    public void Start()
    {
        Button boton = GetComponent<Button>();
        boton.onClick.AddListener(() => ChangeColor(boton));
    }

    public void ChangeColor(Button boton)
    {
        boton.image.color = Color.red;
        boton.enabled = false;
        contador++;
    }
}
