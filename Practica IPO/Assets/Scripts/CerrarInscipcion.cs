using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CerrarInscipcion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject scen = GameObject.Find("ControlerEscenas");
        Button esteBoton = GetComponent<Button>();
        esteBoton.onClick.AddListener(scen.GetComponent<RecargarPagina>().Recargar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
