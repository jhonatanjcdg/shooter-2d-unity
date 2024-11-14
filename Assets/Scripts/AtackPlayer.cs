using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
    public GameObject proyectilPrefab;  // Prefab del proyectil
    public Transform puntoDeDisparo;  // Lugar desde donde se dispara
    
    public float speedAtack;
    public float contSpeed;

    public bool disparoAutomatico = false;  // Variable para habilitar el disparo automático
    public float rangoBusquedaEnemigos = 10f;  // Rango para buscar al enemigo más cercano

    void Start()
    {
        speedAtack = StatisticsPlayer.instance.speedAtack;
        contSpeed = speedAtack;
    }

    void Update()
    {
        speedAtack = 1 / StatisticsPlayer.instance.speedAtack;

        if (contSpeed >= speedAtack)
        {
            if (disparoAutomatico)
            {
                DispararAutomatico();
            }
            else
            {
                // Detectar input para disparar (espacio o clic)
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    DispararHaciaClic();
                    contSpeed = 0f;
                }
            }
        }

        contSpeed += Time.deltaTime;  // Aumentar el contador de tiempo
    }

    void Disparar()
    {
        // Instanciar el proyectil en el punto de disparo
        Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
    }

    void DispararHaciaClic()
    {
        // Obtener la posición del mouse en coordenadas del mundo
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección desde el punto de disparo hacia el clic del mouse
        Vector2 direccionDisparo = (posicionMouse - puntoDeDisparo.position);

        // Instanciar el proyectil en el punto de disparo
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, Quaternion.identity);

        // Configurar la dirección del proyectil hacia el clic
        proyectil.GetComponent<Proyectil>().ConfigurarDireccion(direccionDisparo);
    }

    void DispararAutomatico()
    {
        // Buscar al enemigo más cercano dentro del rango
        GameObject enemigoCercano = BuscarEnemigoCercano();

        if (enemigoCercano != null)
        {
            // Calcular la dirección hacia el enemigo
            Vector2 direccionDisparo = (enemigoCercano.transform.position - puntoDeDisparo.position).normalized;

            // Instanciar el proyectil en el punto de disparo
            GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, Quaternion.identity);

            // Configurar la dirección del proyectil hacia el enemigo
            proyectil.GetComponent<Proyectil>().ConfigurarDireccion(direccionDisparo);

            // Resetear el contador de disparo
            contSpeed = 0f;
        }
    }

    GameObject BuscarEnemigoCercano()
    {
        GameObject enemigoCercano = null;
        float distanciaMinima = rangoBusquedaEnemigos;

        // Buscar todos los enemigos en el rango
        foreach (GameObject enemigo in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float distancia = Vector3.Distance(puntoDeDisparo.position, enemigo.transform.position);

            if (distancia < distanciaMinima)
            {
                enemigoCercano = enemigo;
                distanciaMinima = distancia;
            }
        }

        return enemigoCercano;
    }
}
