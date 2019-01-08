using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GuardarOfertas : MonoBehaviour
{

    List<Ofertas> listaOfertas;
    public InputField tit;
    public InputField emp;
    public InputField desc;
    public InputField fechIn;
    public InputField fechaFin;
    Ofertas oferta;
    private int id;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        id = 0;
        listaOfertas = new List<Ofertas>();
        oferta = new Ofertas();
        CargarOfertas();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarOfertas()
    {
        string jsonToLoad = PlayerPrefs.GetString("LasOfertas");
        //Load as Array
        Ofertas[] _tempLoadListData = JsonHelper.FromJson<Ofertas>(jsonToLoad);
        //Convert to List
        listaOfertas = _tempLoadListData.OfType<Ofertas>().ToList();
        if (listaOfertas.Count != 0)
        {
            CalcularId();
        }
        
    }

    private void CalcularId()
    {
        Debug.Log("Calculo el id");
        foreach(Ofertas oferta in listaOfertas)
        {
            if (oferta.id >= id)
            {
                id = oferta.id;
            }
        }
    }

    public void SaveJson()
    {
        oferta.id = id+1;
        oferta.titulo = tit.text;
        oferta.empresa = emp.text;
        oferta.descripcion = desc.text;
        oferta.fechaInicio = fechIn.text;
        oferta.fechaFinal = fechaFin.text;
        listaOfertas.Add(oferta);
        id++;

        string json = JsonHelper.ToJson(listaOfertas.ToArray(),true);
        //string json = JsonUtility.ToJson(oferta);

        System.IO.File.WriteAllText(@"D:\GitHub\Practica Interacción Persona Ordenador\Practica-IPO\Practica IPO\Assets\Scripts\DB\ofertas.json", json);

        PlayerPrefs.SetString("LasOfertas", json);
        PlayerPrefs.Save();
        //System.IO.File.WriteAllText(@"D:\path.txt", json);
    }

}
