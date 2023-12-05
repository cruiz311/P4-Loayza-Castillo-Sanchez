using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Verificar_usuario : MonoBehaviour
{
    public Database_firebase database_Firebase;
    public TextMeshProUGUI text_respuesta;
    public GameObject inputfield;
    public GameObject canvas_juego;

    public void Verificar_usuario_(string id_)
    {
        if(id_!="1"&& id_ != "2" && id_ != "3")
        {
            text_respuesta.text = "Escoge entre 1,2,3";
        }
        else
        {

            //Seteamos el id del jugador local
            database_Firebase.id = int.Parse(id_);
            //Llamamos a la base de datos si el id escogido
            StartCoroutine(database_Firebase.GetActivo(On_recibir_respuesta));
        }
    }

       

    public void On_recibir_respuesta(bool respuesta_)
    {
        if (respuesta_ == true)
        {
            text_respuesta.text = "Escoge otro id";
        }
        else
        {

            text_respuesta.text = "Escogido exitosamente"+"id: "+database_Firebase.id;
            inputfield.SetActive(false);
            database_Firebase.activo = true;
            database_Firebase.Crear_jugador_();

            //CODIGO PARA MOSTRAR EL JUEGO
            canvas_juego.SetActive(true);
        }
    }
    
}
