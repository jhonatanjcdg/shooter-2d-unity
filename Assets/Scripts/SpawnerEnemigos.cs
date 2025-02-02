using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public GameObject[] tiposDeEnemigos;  // Array de prefabs de diferentes tipos de enemigos
    public float tiempoEntreSpawns = 2f;  // Tiempo entre cada aparición de enemigos
    public float limiteIzquierdo = -9f;  // Límite izquierdo del área de spawn
    public float limiteDerecho = 9f;  // Límite derecho del área de spawn
    public float alturaDeSpawn = 6f;  // Altura de la pantalla donde los enemigos aparecerán
    public GameObject containerEnemies;

    private float tiempoSiguienteSpawn;

    public int enemiesSpawnCount = 0;

    void Update()
    {
        // Controlar el tiempo entre spawns
        if (Time.time >= tiempoSiguienteSpawn && tiposDeEnemigos.Length > 0)
        {
            SpawnearEnemigo();
            enemiesSpawnCount++;
            tiempoSiguienteSpawn = Time.time + tiempoEntreSpawns;
        }
    }

    void SpawnearEnemigo()
    {
        // Elegir una posición aleatoria en la parte superior de la pantalla
        float posicionX = Random.Range(limiteIzquierdo, limiteDerecho);
        Vector2 posicionDeSpawn = new Vector2(posicionX, alturaDeSpawn);

        // Elegir aleatoriamente un tipo de enemigo del array
        int indiceEnemigo = Random.Range(0, tiposDeEnemigos.Length);

        // Instanciar el enemigo en la posición aleatoria
        GameObject enemy = Instantiate(tiposDeEnemigos[indiceEnemigo], posicionDeSpawn, Quaternion.identity);
        enemy.transform.SetParent(containerEnemies.transform);
    }
}
