using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_juego_database : MonoBehaviour
{
    Database_firebase database_Firebase;


    public bool jugador_1_envio;
    public bool jugador_2_envio;
    public bool jugador_3_envio;



    private float contador = 0;
    private bool termino;
    private void Update()
    {
        if (termino == false)
        {
            if (jugador_1_envio && jugador_2_envio && jugador_3_envio)
            {
                On_Todos_los_juegadores_terminaron();
            }
            termino = true;
        }
        
        
    }



    private void On_Todos_los_juegadores_terminaron()
    {

    }

    private void FixedUpdate()
    {
        contador = contador + Time.deltaTime;
        if (contador > 3)
        {
            StartCoroutine(database_Firebase.GetJuegoEnviado(1, On_Juego_Enviado_jugador_1));
            StartCoroutine(database_Firebase.GetJuegoEnviado(2, On_Juego_Enviado_jugador_2));
            StartCoroutine(database_Firebase.GetJuegoEnviado(3, On_Juego_Enviado_jugador_3));
            contador = 0;
        }
      
    }


    public void On_Juego_Enviado_jugador_1(bool juego_enviado_value) {

        jugador_1_envio = true;
    }
    public void On_Juego_Enviado_jugador_2(bool juego_enviado_value)
    {
        jugador_2_envio = true;

    }
    public void On_Juego_Enviado_jugador_3(bool juego_enviado_value)
    {

        jugador_3_envio = true;
    }
}
