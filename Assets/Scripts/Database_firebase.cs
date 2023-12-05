using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;

public class Database_firebase : MonoBehaviour
{
    private DatabaseReference databaseReference;
   //INFORMACION JUGADOR LOCAL
    public int id;
    public bool activo;
    public bool juego_enviado;
    public int[] posiciones_;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        
        //GetUserInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //CREAMOS AL JUGADOR LOCAL
    public void Crear_jugador_()
    {
        Invoke("Crear_jugador", 1f);
    }
    //ACTUALIZAMOS JUGADOR LOCAL
    public void Actualizar_jugador()
    {
        Jugador jugador = new Jugador(id, posiciones_,activo,juego_enviado);
        string json = JsonUtility.ToJson(jugador);
        databaseReference.Child("Partida").Child("Jugador_" + id).SetRawJsonValueAsync(json);
    }
    private void Crear_jugador()
    {
        
        Jugador jugador = new Jugador(id, posiciones_,activo,juego_enviado);
        string json = JsonUtility.ToJson(jugador);
        databaseReference.Child("Partida").Child("Jugador_" + id).SetRawJsonValueAsync(json);
    }
    
    

    //private IEnumerator GetLastName(Action<string> onCallBack)
    //{
    //    var userNameData = databaseReference.Child("users").Child(userID).Child("lastName").GetValueAsync();

    //    yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

    //    if (userNameData != null)
    //    {
    //        DataSnapshot snapshot = userNameData.Result;
    //        onCallBack?.Invoke(snapshot.Value.ToString());
    //    }
    //}

    public IEnumerator GetActivo(Action<bool> onCallBack)
    {
        var userNameData = databaseReference.Child("Partida").Child("Jugador_" + id).Child(nameof(Jugador.activo)).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //(int) -> Casting
            //int.Parse -> Parsing
            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
            onCallBack?.Invoke((bool)snapshot.Value);
        }
    }
    public IEnumerator GetJuegoEnviado(int id_jugador,Action<bool> onCallBack)
    {
        var userNameData = databaseReference.Child("Partida").Child("Jugador_" + id_jugador).Child(nameof(Jugador.juego_enviado)).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //(int) -> Casting
            //int.Parse -> Parsing
            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
            onCallBack?.Invoke((bool)snapshot.Value);
        }
    }
    public IEnumerator GetPosiciones(int id_jugador, Action<int[]> onCallBack)
    {
        var userNameData = databaseReference.Child("Partida").Child("Jugador_" + id_jugador).Child(nameof(Jugador.posiciones)).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //(int) -> Casting
            //int.Parse -> Parsing
            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
            onCallBack?.Invoke((int[])snapshot.Value);
        }
    }


    public void GetUserInfo()
    {
        //StartCoroutine(GetFirstName(PrintData));
        //StartCoroutine(GetLastName(PrintData));
        StartCoroutine(GetActivo(PrintData));
        StartCoroutine(GetPosiciones(1,PrintData));
    }

    private void PrintData(string name)
    {
        Debug.Log(name);
    }

    private void PrintData(int code)
    {
        Debug.Log(code);
    }
    private void PrintData(int[] code)
    {
        for (int i = 0; i < code.Length; i++)
        {
            Debug.Log(code[i]);
        }
    }

    private void PrintData(bool code)
    {
        Debug.Log(code);
    }
}
public class User
{
    public string firstName;
    public string lastName;
    
    public int codeID;
    public User(string firstName, string lastName, int codeID)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.codeID = codeID;
    }
}
public class Jugador
{
    public int id;
    public bool activo;
    public bool juego_enviado;
    public int[] posiciones=new int[3];

    public Jugador(int id_,int[] posiciones_,bool activo_,bool juego_enviado_)
    {
        id = id_;
        posiciones = posiciones_;
        activo = activo_;
        juego_enviado = juego_enviado_;
    }
}