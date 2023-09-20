using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float _playerSpeed = 5;

    [SerializeField]private float _jumpForce = 5;    

    private float _playerInputHorizontal; 
    private float _playerInputVertical;

    private Rigidbody2D _rBody2D;
    private GroundSensor _sensor;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor =GetComponentInChildren<GroundSensor>();
    }

    // Update is called once per frame
    void Update()
    {
      PlayerMovement();

      if(Input.GetButtonDown("Jump") && _sensor._isGrounded)
      {
        Jump();
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

    }

    void Jump()
    {
       _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

    }

}


