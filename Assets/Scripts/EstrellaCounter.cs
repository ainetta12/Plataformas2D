using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstrellaCounter : MonoBehaviour
{

    public static EstrellaCounter instance;

    public TMP_Text estrellaText;
    public int currentEstrella = 0;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        estrellaText.text = "ESTRELLAS: " + currentEstrella.ToString();
    }

    public void IncreaseEstrellas(int v)
    {
        currentEstrella += v;
        estrellaText.text = "ESTRELLAS: " + currentEstrella.ToString();
    }
}
