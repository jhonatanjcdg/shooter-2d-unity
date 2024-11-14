using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textDamage;
    public TextMeshProUGUI textSpeed;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textHealing;

    public StatisticsPlayer player;

    public Image healthPlayerImage;

    void Start()
    {
        player = StatisticsPlayer.instance;
    }

    void Update()
    {
        // Actualizar texto del costo de las mejoras
        textPoints.text = player.points.ToString();
        textDamage.text = player.damageCost.ToString();
        textSpeed.text = player.speedAtackCost.ToString();
        textHealth.text = player.healthCost.ToString();
        textHealing.text = player.speedRegenHealthCost.ToString();
        
        // Actualizar imagen del health player
        healthPlayerImage.fillAmount = (float)player.health / (float)player.healthMax;
    }
}
