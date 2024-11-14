using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float pointsDropped = 10f;
    public float vida = 100f;
    public float velocidad = 2f;
    public float danioAlJugador = 20f;
    public Transform jugador;
    public bool destruirSiTocaJugador = true;

    void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Proyectil"))
        {
            RecibirDanio(StatisticsPlayer.instance.damage);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<StatisticsPlayer>().RecibirDanio(danioAlJugador);

            if (destruirSiTocaJugador)
                DestruirEnemigo();
        }
    }

    public void RecibirDanio(float cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            DestruirEnemigo();
        }
    }

    void DestruirEnemigo()
    {
        StatisticsPlayer.instance.AgregarPuntos(pointsDropped);

        var flyingAttack = GetComponent<FlyingAttack>();
        if (flyingAttack != null && flyingAttack.roboRealizado && !flyingAttack.roboDevuelto2)
        {
            flyingAttack.DevolverEstadisticas();
        }

        Destroy(gameObject);
    }
}
