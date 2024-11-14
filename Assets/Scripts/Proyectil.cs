using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;  // Velocidad del proyectil
    public float tiempoDeVida = 5f;  // Tiempo hasta que se destruye automáticamente
    private Vector2 direccion;  // Dirección hacia donde se moverá el proyectil
    public float tiempoDeMostrarDaño = 1f;
    public GameObject textDamage;

    void Start()
    {
        // Destruir el proyectil después de un tiempo
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    // Detectar colisiones con los enemigos
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Destruir el proyectil
            Destroy(gameObject);

            // Mostrar daño en pantalla
            GameObject newText = Instantiate(textDamage);
            newText.transform.SetParent(collision.transform);
            newText.transform.localPosition = new Vector3(0, 0.8f, 0);
            newText.GetComponent<TextMeshPro>().text = StatisticsPlayer.instance.damage.ToString();
            newText.AddComponent<ObjectDestroyer>();

            // Reducir la vida del enemigo
            collision.GetComponent<Enemy>().RecibirDanio(StatisticsPlayer.instance.damage);
        }
    }

    public void ConfigurarDireccion(Vector2 direccionObjetivo)
    {
        direccion = direccionObjetivo.normalized;  // Normalizamos la dirección para que tenga magnitud 1
    }
}
