using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{


    Animator anim;
    BoxCollider2D boxCollider;

    BGMManager bgmManager;
    SoundManager soundManager;
    GameManager gameManager;

    float horizontal = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
   
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void Die()
    {
        anim.SetBool("IsDead", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player muerto");
            Destroy(collision.gameObject);
            bgmManager.StopBGM();
            soundManager.DeathSound();
            soundManager.DestroyBomb();
            gameManager.GameOver();
            Debug.Log("Scene");
            gameManager.GameOverScene();
        }


    }

}
