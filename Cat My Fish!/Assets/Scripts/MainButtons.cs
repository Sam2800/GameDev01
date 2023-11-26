using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelNiveles;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private GameObject panelJugar;
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCapturado;
    [SerializeField] private GameObject panelAlcanzado;

    public void BAlcanzado()
    {
        panelAlcanzado.SetActive(false);
        panelJugar.SetActive(true);
    }

    public void BCapturado()
    {
        panelCapturado.SetActive(false);
        panelJugar.SetActive(true);
    }

    public void BJugar()
    {
        panelJugar.SetActive(false);
        panelNiveles.SetActive(true);
    }

    public void Alcanzado()
    {
        panelJugar.SetActive(false);
        panelAlcanzado.SetActive(true);
    }

    public void Capturado()
    {
        panelJugar.SetActive(false);
        panelCapturado.SetActive(true);
    }

    public void BControles()
    {
        panelControles.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void BOpciones()
    {
        panelOpciones.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void BNiveles()
    {
        panelNiveles.SetActive(false);
        panelInicio.SetActive(true);
    }

    public void Opciones()
    {
        panelInicio.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void Niveles()
    {
        panelInicio.SetActive(false);
        panelNiveles.SetActive(true);
    }

    public void Controles()
    {
        panelInicio.SetActive(false);
        panelControles.SetActive(true);
    }

    public void Jugar()
    {
        panelNiveles.SetActive(false);
        panelJugar.SetActive(true);
    }
}
