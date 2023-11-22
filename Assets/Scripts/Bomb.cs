using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    /*[Serializefield] private float radio;
    [SerializeField] private float fuerzaExplosion;
    
    public void Update()
    {
        if (Input. GetKeyDown(KeyCode.P)
        {
            Explosion;
        }
    }

    public void Explosion ()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach(Collider2D collider in objetos)
        {
            Rigidbody2D rB2D = collider.GetComponent < Rigidbody2D>();
            if (rB2D = collider.transform.position = transform.position;
            float distancia
        }*/

    Animator anim;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;

    BGMManager bgmManager;
    SoundManager soundManager;
    GameManager gameManager;

    float horizontal = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rBody = GetComponent<Rigidbody2D>();

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
            //sceneManager.LoadScene(2);
            gameManager.GameOver();
        }

        if (collision.gameObject.tag == "ColllisionBomb")
        {
            if (horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ColllisionBomb")
        {
            if (horizontal == 1)
            {
                horizontal = -1;
            }
            else
            {
                horizontal = 1;
            }
        }
    }

}
