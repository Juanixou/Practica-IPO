using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarInscripción : MonoBehaviour
{
    List<Inscripciones> listaInscripciones;
    Inscripciones inscripcion;
    //public GameObject mensaje;
    public GameObject boton;

    // Start is called before the first frame update
    void Start()
    {
        inscripcion = new Inscripciones();
        listaInscripciones = new List<Inscripciones>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Guardar(GameObject hijo, GameObject mensaje)
    {
        
        inscripcion.id = int.Parse(hijo.transform.parent.name);
        Debug.Log(inscripcion.id);
        inscripcion.estado = "Apuntado";
        Debug.Log(inscripcion.estado);
        listaInscripciones.Add(inscripcion);
        string json = JsonHelper.ToJson(listaInscripciones.ToArray(), true);

        System.IO.File.WriteAllText(@"D:\GitHub\Practica Interacción Persona Ordenador\Practica-IPO\Practica IPO\Assets\Scripts\DB\inscripciones.json", json);

        PlayerPrefs.SetString("LasInscripciones", json);
        PlayerPrefs.Save();
        mensaje.SetActive(true);
        hijo.SetActive(false);
    }
}
