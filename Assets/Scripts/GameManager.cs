using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject containerEnemies;

    public LevelManager levelManager;

    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy(gameObject);
        }
    }

    public void RestartGame()
    {
        // Iterar sobre todos los hijos del contenedor
        // foreach (Transform child in containerEnemies.transform)
        // {
        //     // Destruir cada enemigo hijo
        //     Destroy(child.gameObject);
        // }
        // StatisticsPlayer.instance.health = StatisticsPlayer.instance.healthMax;
        levelManager.RestartLevel();
    }

    public void ChangeScene(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogError("Error al cargar la escena con el nombre nullo o no existe");
        }
    }
}
