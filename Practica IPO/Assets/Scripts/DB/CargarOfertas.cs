using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CargarOfertas : MonoBehaviour
{
    List<Ofertas> todasLasOfertas;
    public GameObject datos;
    public GameObject scrollView;
    private GameObject objetoInstanciado;

    // Start is called before the first frame update
    void Start()
    {
        todasLasOfertas = new List<Ofertas>();

    }

    private void Awake()
    {
        CargarLasOfertas();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarLasOfertas()
    {
        string jsonToLoad = PlayerPrefs.GetString("LasOfertas");
        //Load as Array
        Ofertas[] _tempLoadListData = JsonHelper.FromJson<Ofertas>(jsonToLoad);
        //Convert to List
        todasLasOfertas = _tempLoadListData.OfType<Ofertas>().ToList();
        int y = 0;
        foreach (Ofertas oferta in todasLasOfertas)
        {
            GameObject aux;
            objetoInstanciado = Instantiate(datos);
            objetoInstanciado.transform.SetParent(scrollView.transform, false);
            objetoInstanciado.transform.Translate(new Vector3(0, y, 0));
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
            y -= 3;
        }
    }

}
