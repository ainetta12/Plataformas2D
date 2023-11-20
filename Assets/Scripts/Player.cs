using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Starts")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]

    [SerializeField] private float _playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje")]

    [SerializeField] private float _jumpForce = 5;

    private float _playerInputHorizontal;
    private float _playerInputVertical;

    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;

    [SerializeField] private Animator _animator;

    [SerializeField] private PlayableDirector _director;

    int contadorEstrella;
    public Text contadorTexto;
    private Estrella estrella;

    private SoundManager soundManager;
    

    //private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();

        Debug.Log(GameManager.instance.vida);

        //_sprite = GetComponentInChildren<SpriteRenderer>();

        contadorEstrella = 0;

        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }

       
    }


    void FixedUpdate()
    {
        // _rBody2D.AddForce(new Vector2(_playerInputHorizontal * _playerSpeed, 0), ForceMode2D.Impulse);

        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }


    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis("Horizontal");
        /* _playerInputVertical = Input.GetAxis("Vertical");

         transform.Translate(new Vector2(_playerInputHorizontal, _playerInputVertical) *_playerSpeed * Time.deltaTime);*/

        if (_playerInputHorizontal != 0)
        {
            _animator.SetBool("IsRunning", true);
        }

        if (_playerInputHorizontal == 0)
        {
            _animator.SetBool("IsRunning", false);
        }

        if (_playerInputHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_playerInputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        soundManager.JumpSound();

        if (_playerInputHorizontal != 0)
        {
            _animator.SetBool("IsJumping", true);
            
        }
        if(_playerInputHorizontal ==0)
        {
            _animator.SetBool("IsJumping", false);
        }
    }

    public void SignalTest()
    {
        Debug.Log("Senal recibida");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            //_soundManager.instance.deathSound();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionMoneda")
        {
            Destroy(collision.gameObject);
            Estrella estrella = collision.gameObject.GetComponent<Estrella>();
            estrella.Die();
            contadorEstrella++;
            contadorTexto.text = "estrella " + contadorEstrella.ToString();
            Debug.Log("contadorEstrella");
            
        }

    }
}


