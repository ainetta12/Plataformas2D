using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool _isGrounded;

    Animator _animator;

    void Start()
    {
        _animator = GameObject.Find("rogue").GetComponent<Animator>();
    }
  
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.layer == 6)
       {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
       }
       
   }

   void OnTriggerExit2D(Collider2D other)
   {
       if(other.gameObject.layer == 6)
       {
            _isGrounded = false;
            _animator.SetBool("IsJumping", true);
       }
   }

   void OnTriggerStay2D(Collider2D other)
   {
       if(other.gameObject.layer == 6)
       {
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
       }
   }
}
