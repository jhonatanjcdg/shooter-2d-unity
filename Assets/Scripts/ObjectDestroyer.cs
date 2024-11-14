using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Tiempo antes de que el objeto se destruya (puede ser configurado en el Inspector)
    public float tiempoDeVida = 0.2f;

    // Se llama cuando el objeto se activa
    void Start()
    {
        // Programar la destrucción del objeto después de 'tiempoDeVida' segundos
        Destroy(gameObject, tiempoDeVida);
    }
}
