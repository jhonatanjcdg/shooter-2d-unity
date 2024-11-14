using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsPlayer : MonoBehaviour
{
    public static  StatisticsPlayer instance;

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

    void FixedUpdate()
    {
        // Update healing speed
        health += speedRegenHealth * Time.deltaTime;
        if(health > healthMax){
            health = healthMax;
        }
        if(health <= 0){
            //  Game Over

        }
    }

    public void RecibirDanio(float cantidad)
    {
        health -= cantidad;
        if (health <= 0)
        {
            // Aquí podrías implementar la lógica de muerte del jugador
            Debug.Log("El jugador ha muerto.");
            // Por ejemplo, podrías deshabilitar al jugador o mostrar una pantalla de Game Over
        }
    }

    public void AgregarPuntos(float cantidad){
        points += cantidad;
    }
}
