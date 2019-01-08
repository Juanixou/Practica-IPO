using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CargarInscripciones : MonoBehaviour
{
    List<Inscripciones> todasLasInscripciones;
    List<Ofertas> todasLasOfertas;
    public GameObject datos;
    private GameObject objetoInstanciado;
    public Transform scrollView;

    // Start is called before the first frame update
    void Start()
    {
        todasLasInscripciones = new List<Inscripciones>();
        CargarLasInscripciones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarLasInscripciones()
    {
        string jsonInsc = PlayerPrefs.GetString("LasInscripciones");
        //Load as Array

        Inscripciones[] _tempLoadListInsc = JsonHelper.FromJson<Inscripciones>(jsonInsc);
        //Convert to List
        todasLasInscripciones = _tempLoadListInsc.OfType<Inscripciones>().ToList();

        string jsonToLoad = PlayerPrefs.GetString("LasOfertas");
        //Load as Array
        Ofertas[] _tempLoadListData = JsonHelper.FromJson<Ofertas>(jsonToLoad);
        //Convert to List
        todasLasOfertas = _tempLoadListData.OfType<Ofertas>().ToList();

        for(int i = 0; i < todasLasInscripciones.Count; i++)
        {
            GameObject aux;
            objetoInstanciado = (GameObject)GameObject.Instantiate(datos);
            objetoInstanciado.transform.SetParent(scrollView);
            objetoInstanciado.transform.localScale = new Vector3(1, 1, 1);

            for(int x = 0; i< todasLasOfertas.Count; x++)
            {
                if(todasLasOfertas[x].id== todasLasInscripciones[i].id)
                {
                    aux = objetoInstanciado.transform.Find("OfertaInText").gameObject;
                    aux.GetComponent<Text>().text = todasLasOfertas[x].titulo;

                    aux = objetoInstanciado.transform.Find("EmpresaInText").gameObject;
                    aux.GetComponent<Text>().text = todasLasOfertas[x].empresa;

                    aux = objetoInstanciado.transform.Find("FechaInText").gameObject;
                    aux.GetComponent<Text>().text = todasLasOfertas[x].fechaInicio;

                    aux = objetoInstanciado.transform.Find("EstadoInText").gameObject;
                    aux.GetComponent<Text>().text = todasLasInscripciones[i].estado;
                }
            }

        }




    }
}
