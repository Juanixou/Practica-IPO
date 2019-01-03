using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlarLoging : MonoBehaviour
{
    //Variables del editor de Unity
    public Text userText;
    public GameObject panelError;
    public GameObject mensajeError;
    public InputField pass;

    //Variables privadas de código
    private string check;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComprobarUsuario()
    {
        panelError.SetActive(false);
        mensajeError.SetActive(false);
        for(int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                check = userText.text;
            }
            else
            {
                //check = passwordText.text;
                check = pass.text;
            }
            switch (check)
            {
                case "Alumno":
                    if (i == 1)
                    {
                        SceneManager.LoadScene("Alumnos");
                    }
                    break;
                case "Profesor":
                    if (i == 1)
                    {
                        SceneManager.LoadScene("Profesores");
                    }
                    break;
                case "Empresa":
                    if (i == 1)
                    {
                        SceneManager.LoadScene("Empresas");
                    }
                    break;
                default:
                    panelError.SetActive(true);
                    mensajeError.SetActive(true);
                    break;
            }
        }

    }
}
