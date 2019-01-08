using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TodasLasEscenas : MonoBehaviour
{
    public void CambiarLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void CambiarAlumnos()
    {
        SceneManager.LoadScene("Alumnos");
    }

    public void CambiarCrearOfertas()
    {
        SceneManager.LoadScene("Crear Oferta");
    }

    public void VerMisOfertas()
    {
        SceneManager.LoadScene("Ver Ofertas");
    }

    public void CambiarANotificaciones()
    {

    }

    public void CambiarEmpresas()
    {
        SceneManager.LoadScene("Empresas");
    }

    public void CambiarOfertasAlumnos()
    {
        SceneManager.LoadScene("Ver Ofertas Alumnos");
    }

    public void CambiarInscripcionesRealizadas()
    {
        SceneManager.LoadScene("Inscripciones Realizadas");
    }

}
