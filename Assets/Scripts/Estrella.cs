using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrella : MonoBehaviour
{

    public int value;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EstrellaCounter.instance.IncreaseEstrellas(value);
            soundManager.EstrellaSound();
        }
    }

}
