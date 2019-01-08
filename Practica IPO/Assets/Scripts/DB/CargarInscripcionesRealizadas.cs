using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CargarInscripcionesRealizadas : MonoBehaviour
{

    List<Ofertas> todasLasOfertas;
    List<Inscripciones> todasLasInscripciones;
    public GameObject datos;
    public Transform scrollView;
    public string escena;
    private GameObject objetoInstanciado;
    private bool continuar = false;

    // Start is called before the first frame update
    void Start()
    {
        todasLasOfertas = new List<Ofertas>();
        todasLasInscripciones = new List<Inscripciones>();
        CargarMisInscripciones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarMisInscripciones()
    {
        string jsonToLoad = PlayerPrefs.GetString("LasOfertas");
        //Load as Array
        Ofertas[] _tempLoadListData = JsonHelper.FromJson<Ofertas>(jsonToLoad);
        //Convert to List
        todasLasOfertas = _tempLoadListData.OfType<Ofertas>().ToList();

        string jsonInsc = PlayerPrefs.GetString("LasInscripciones");
        //Load as Array

        Inscripciones[] _tempLoadListInsc = JsonHelper.FromJson<Inscripciones>(jsonInsc);
        //Convert to List
        todasLasInscripciones = _tempLoadListInsc.OfType<Inscripciones>().ToList();

        foreach (Ofertas oferta in todasLasOfertas)
        {

                for (int i = 0; i < todasLasInscripciones.Count; i++)
                {
                    if (todasLasInscripciones[i].id == oferta.id)
                    {
                        GameObject aux;
                        objetoInstanciado = (GameObject)GameObject.Instantiate(datos);
                        objetoInstanciado.transform.SetParent(scrollView);
                        objetoInstanciado.transform.localScale = new Vector3(1, 1, 1);
                        objetoInstanciado.name = oferta.id.ToString();

                        aux = objetoInstanciado.transform.Find("TituloText").gameObject;
                        aux.GetComponent<Text>().text = oferta.titulo;

                        aux = objetoInstanciado.transform.Find("EmpresaText").gameObject;
                        aux.GetComponent<Text>().text = oferta.empresa;

                        aux = objetoInstanciado.transform.Find("DescripcionText").gameObject;
                        aux.GetComponent<Text>().text = oferta.descripcion;

                        aux = objetoInstanciado.transform.Find("FechaIniText").gameObject;
                        aux.GetComponent<Text>().text = oferta.fechaInicio;

                        aux = objetoInstanciado.transform.Find("FechaFinText").gameObject;
                        aux.GetComponent<Text>().text = oferta.fechaFinal;
                    }
                }

            
        }
    }

}
