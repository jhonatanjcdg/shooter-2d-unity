using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public SpawnerEnemigos spawnerEnemies;

    void Update()
    {
        if(spawnerEnemies.enemiesSpawnCount >= 10){
            // NextLevel, con menú o escena de transición
            spawnerEnemies.tiposDeEnemigos = new GameObject[0];
        }
    }

    public void RestartLevel(){
        // Reiniciar el nivel actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
