using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Busca_Iguales : MonoBehaviour
{
    public GameObject[] bolasXD;
    public int[] repeticiones;
    // Start is called before the first frame update
    void Start()
    {
        int[] arregloOriginal = { 1, 2, 3, 2, 5, 3, 7, 2, 1 };

        repeticiones = EncontrarRepeticiones(arregloOriginal);

        MostrarResultados(arregloOriginal, repeticiones);
    }

    void Update()
    {
        Actualizar_Tag();
    }


    void Actualizar_Tag()
    {
        for (int i = 0; i < repeticiones.Length; i++)
        {
            bolasXD[(repeticiones[i]-1)].gameObject.tag = "Error";
        }
    }
    int[] EncontrarRepeticiones(int[] arreglo)
    {
        List<int> repeticiones = new List<int>();
        List<int> elementosVistos = new List<int>();

        foreach (int numero in arreglo)
        {
            if (elementosVistos.Contains(numero) && !repeticiones.Contains(numero))
            {
                repeticiones.Add(numero);
            }
            else
            {
                elementosVistos.Add(numero);
            }
        }

        return repeticiones.ToArray();
    }

    void MostrarResultados(int[] arregloOriginal, int[] repeticiones)
    {
        Debug.Log("Arreglo: " + string.Join(", ", arregloOriginal));
        Debug.Log("numeros repetidos: " + string.Join(", ", repeticiones));
    }
}
