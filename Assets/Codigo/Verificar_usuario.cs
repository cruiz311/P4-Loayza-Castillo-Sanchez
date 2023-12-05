using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Verificar_usuario : MonoBehaviour
{
    public Database_firebase database_Firebase;
    public TextMeshProUGUI activo;
    public GameObject inputfield;

    public void Verificar_usuario_(string id_)
    {
        if(id_!="1"&& id_ != "2" && id_ != "3")
        {
            activo.text = "Escoge entre 1,2,3";
        }
        else
        {
           
            database_Firebase.id = int.Parse(id_);
            StartCoroutine(database_Firebase.GetActivo(On_recibir_respuesta));
        }
    }

       

    public void On_recibir_respuesta(bool respuesta_)
    {
        if (respuesta_ == true)
        {
            activo.text = "Escoge otro id";
        }
        else
        {
            activo.text = "Escogido exitosamente";
            inputfield.SetActive(false);
        }
    }
    
}
