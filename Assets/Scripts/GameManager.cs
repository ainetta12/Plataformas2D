using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{get; private set;}
    public int vida;

    public Text estrellaText;

    int estrellas;

    public bool isGameOver;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void AddEstrella()
    {
        estrellas++;
        estrellaText.text = estrellas.ToString();
    }

}
