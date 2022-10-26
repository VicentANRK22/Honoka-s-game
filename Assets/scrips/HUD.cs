using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;


    private void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();

    }
}
