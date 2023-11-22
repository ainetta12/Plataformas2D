using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour

{
    public static SoundManager instance { get; private set; }

      AudioSource _SfxAudio;
      [SerializeField]private AudioClip deathSound;
      [SerializeField]private AudioClip jumpSound;
      [SerializeField]private AudioClip bgmSound;


      void Awake()
      {
          _SfxAudio = GetComponent<AudioSource>();

          if (instance != null && instance != this)
          {
              Destroy(this.gameObject);
          }
          else
          {
              instance = this;
          }
      }

      public void DeathSound()
      {
          _SfxAudio.PlayOneShot(deathSound);
      }

      public void JumpSound()
      {
          _SfxAudio.PlayOneShot(jumpSound);
      }


}
