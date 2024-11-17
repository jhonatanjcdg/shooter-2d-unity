using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosManager : MonoBehaviour
{
    public bool disparoAutomatico = false;

    void Start()
    {
        disparoAutomatico = StatisticsPlayer.instance.GetComponent<AtackPlayer>().disparoAutomatico;
    }
    public void CambiarEstadoDisparoAutomatico(){
        disparoAutomatico = !StatisticsPlayer.instance.GetComponent<AtackPlayer>().disparoAutomatico;
        StatisticsPlayer.instance.GetComponent<AtackPlayer>().disparoAutomatico = disparoAutomatico;
    }
}
