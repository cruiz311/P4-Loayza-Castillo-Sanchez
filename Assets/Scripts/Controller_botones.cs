using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller_botones : MonoBehaviour
{
    public TMP_Text contador_text;
    public Database_firebase database_Firebase;
    public int contador = 0;
    public int[] botones_escogidos = new int[3];

    public  List<Button> botones;

    private void Update()
    {
        contador_text.text = contador.ToString() + "/3";
    }
    public void On_click_button_(string id_button)
    {

        botones_escogidos[contador] = int.Parse(id_button);
             contador++;
        if (contador == 3)
        {
            Desactivar_botones();
            Actualizar_jugador();
        }
    }
    public void Actualizar_jugador()
    {
        database_Firebase.posiciones_ = botones_escogidos;
        database_Firebase.juego_enviado = true;

        database_Firebase.Actualizar_jugador();
    }

    public void Desactivar_botones()
    {
        foreach (Button item in botones)
        {
            item.enabled = false;
        }
    }

}
