using System.Collections;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    public float rangoDeAtaque = 2f;          // Distancia para iniciar el ataque
    public float velocidadDeAtaque = 2f;     // Tiempo entre ataques
    private float auxVelocidadDeAtaque;      // Contador para manejar la velocidad de ataque
    public Animator animator;                // Controlador de animaciones
    private Enemy enemyScript;               // Referencia al script del enemigo
    private bool atacando = false;           // Estado del enemigo (atacando o no)
    private Vector3 posFija;                 // Posición donde el enemigo se detiene

    void Awake()
    {
        auxVelocidadDeAtaque = velocidadDeAtaque;
        enemyScript = GetComponent<Enemy>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verificar la distancia al jugador
        if (!atacando && Vector3.Distance(transform.position, enemyScript.jugador.position) <= rangoDeAtaque)
        {
            // Fijar la posición actual y detener el movimiento
            posFija = transform.position;
            atacando = true;
            StartCoroutine(AtacarContinuamente());
        }

        // Si está atacando, asegurarse de que no se mueva
        if (atacando)
        {
            transform.position = posFija;
        }
    }

    IEnumerator AtacarContinuamente()
    {
        while (atacando)
        {
            // Animación de ataque
            animator.SetTrigger("Attack");

            // Infligir daño al jugador
            DamageToPlayer(enemyScript.danioAlJugador);

            // Esperar antes del siguiente ataque
            yield return new WaitForSeconds(velocidadDeAtaque);
        }
    }

    public void DamageToPlayer(float damage)
    {
        // Método para infligir daño al jugador
        StatisticsPlayer.instance.RecibirDanio(damage);
    }

    public void DetenerAtaque()
    {
        // Método opcional para detener el ataque desde otro script
        atacando = false;
    }
}
