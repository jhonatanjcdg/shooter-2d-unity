using System.Collections;
using UnityEngine;

public class FlyingAttack : MonoBehaviour
{
    public float roboDeEstadisticas = 5f;
    public float rangoDeAtaque = 2f;
    public float tiempoDevolverEstadisticasJugador = 3f;
    public Animator animator;
    private Enemy enemyScript;
    private bool atacando = false;
    public bool roboRealizado = false;
    public bool roboDevuelto = false;
    public bool roboDevuelto2 = false;
    public float estadisticaSpeedAtackRobada;
    public float estadisticaDamageRobada;

    void Awake()
    {
        enemyScript = GetComponent<Enemy>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!atacando && Vector3.Distance(transform.position, enemyScript.jugador.position) <= rangoDeAtaque)
        {
            StartCoroutine(AtacarYTeletransportar());
        }
    }

    IEnumerator AtacarYTeletransportar()
    {
        atacando = true;
        animator.SetTrigger("Attack");

        if (!roboRealizado)
        {
            estadisticaSpeedAtackRobada = StatisticsPlayer.instance.speedAtack * (roboDeEstadisticas / 100);
            estadisticaDamageRobada = StatisticsPlayer.instance.damage * (roboDeEstadisticas / 100);

            StatisticsPlayer.instance.speedAtack -= estadisticaSpeedAtackRobada;
            StatisticsPlayer.instance.damage -= estadisticaDamageRobada;
            roboRealizado = true;
        }

        StatisticsPlayer.instance.RecibirDanio(enemyScript.danioAlJugador);

        yield return new WaitForSeconds(1f);

        Teletransportarse();
        animator.SetTrigger("Idle");
        atacando = false;

        if (!roboDevuelto && roboRealizado)
        {
            roboDevuelto = true;
            yield return new WaitForSeconds(tiempoDevolverEstadisticasJugador);
            DevolverEstadisticas();
        }
    }

    void Teletransportarse()
    {
        float x = UnityEngine.Random.Range(-2f, 2f);
        Vector3 nuevaPosicion = transform.position - new Vector3(x, -2f, 0);
        transform.position = nuevaPosicion;

        enemyScript.vida += enemyScript.vida * (roboDeEstadisticas / 100) * 2;
    }

    public void DevolverEstadisticas()
    {
        if (roboRealizado && !roboDevuelto2)
        {
            StatisticsPlayer.instance.speedAtack += estadisticaSpeedAtackRobada;
            StatisticsPlayer.instance.damage += estadisticaDamageRobada;
            roboDevuelto2 = true;
        }
    }
}
