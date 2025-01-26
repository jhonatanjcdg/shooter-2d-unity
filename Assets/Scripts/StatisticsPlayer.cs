using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsPlayer : MonoBehaviour
{
    public static StatisticsPlayer instance;

    public float points = 100f;

    public float damage = 1f;
    public float healthMax = 10f;
    public float health = 10f;
    public float speedAtack = 1f;
    public float speedRegenHealth = 0.5f;

    public float damageCost = 10f;
    public float healthCost = 10f;
    public float speedAtackCost = 10f;
    public float speedRegenHealthCost = 10f;

    public GameObject gameOverPanel;

    void Awake()
    {
        // Asegurarse de que solo haya una instancia de StatisticsPlayer
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Evita que el objeto se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject);  // Destruye cualquier instancia duplicada
        }

        health = healthMax;
    }

    void Start()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("gameover");

        if (gameOverPanel != null)
        {
            // Asegurarte de que esté desactivado al inicio
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'gameover'");
        }
    }

    void FixedUpdate()
    {
        // Update healing speed
        health += speedRegenHealth * Time.deltaTime;
        if (health > healthMax)
        {
            health = healthMax;
        }
        if (health <= 0)
        {
            //  Game Over

        }
    }

    public void RecibirDanio(float cantidad)
    {
        health -= cantidad;
        if (health <= 0)
        {
            // Pantalla game over
            GameOver();
            Debug.Log("Player died");
        }
    }

    void GameOver()
    {
        if (gameOverPanel != null)
        {
            // Activar el panel de Game Over
            gameOverPanel.SetActive(true);

            // Pausar el juego
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Error setting gameoverPanel to true");
        }
    }

    public void AgregarPuntos(float cantidad)
    {
        points += cantidad;
    }
}
