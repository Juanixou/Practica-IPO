using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInscripcion : MonoBehaviour
{
    GameObject inscript;
    public GameObject mens;
    // Start is called before the first frame update
    void Start()
    {
        inscript = GameObject.Find("Inscripciones");
        Button esteBoton = GetComponent<Button>();
        esteBoton.onClick.AddListener(delegate { inscript.GetComponent<GuardarInscripción>().Guardar(this.gameObject,mens); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
