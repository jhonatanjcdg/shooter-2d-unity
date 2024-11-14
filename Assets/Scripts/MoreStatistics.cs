using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreStatistics : MonoBehaviour
{
    private StatisticsPlayer player;
    void Start()
    {
        player = StatisticsPlayer.instance;
    }
    public void DamageUp(float cantidad){
        // Agrega daño y aumenta su valor para mejorar
        // Primero verifica si tiene suficientes puntos para mejorar
        if(player.points >= player.damageCost){
            player.damage += cantidad;
            player.damageCost *= 1.2f;
        }
    }
    public void SpeedAtackUp(float cantidad){
        // Aumenta velocidad de ataque y aumenta su valor para mejorar
        // Primero verifica si tiene suficientes puntos para mejorar
        if(player.points >= player.speedAtackCost){
            player.speedAtack += cantidad;
            player.speedAtackCost *= 1.2f;
        }
    }
    public void HealthUp(float cantidad){
        // Aumenta salud y aumenta su valor para mejorar
        // Primero verifica si tiene suficientes puntos para mejorar
        if(player.points >= player.healthCost){
            player.healthMax += cantidad;
            player.healthCost *= 1.2f;
        }
    }
    public void HealthSpeedRegenUp(float cantidad){
        // Aumenta velocidad de regeneración de salud y aumenta su valor para mejorar
        // Primero verifica si tiene suficientes puntos para mejorar
        if(player.points >= player.speedRegenHealthCost){
            player.speedRegenHealth += cantidad;
            player.speedRegenHealthCost *= 1.2f;
        }
    }
}
