using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Text textHealthImage;

    void Start()
    {
        player = StatisticsPlayer.instance;
    }

    void Update()
    {
        // Actualizar texto del costo de las mejoras
        textPoints.text = "" + (int) player.points;
        textDamage.text = "" + (int) player.damageCost;
        textSpeed.text = "" + (int) player.speedAtackCost;
        textHealth.text = "" + (int) player.healthCost;
        textHealing.text = "" + (int) player.speedRegenHealthCost;
        
        // Actualizar imagen del health player
        healthPlayerImage.fillAmount = (float)player.health / (float)player.healthMax;
        textHealthImage.text = (player.health > 0)?(int) player.health + "/" + (int) player.healthMax: "0";
    }
}
