using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffectControl : MonoBehaviour
{
    public AudioClip[] ExplosionSoundEffects;

    AudioSource ExplosionSound;

    void Awake()
    {
        ExplosionSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        switch (this.gameObject.name)
        {
            case "Aerial Explosion(Clone)":
                if (ExplosionSound.isPlaying != false)
                {
                    return;
                }
                else
                {
                    ExplosionSound.PlayOneShot(ExplosionSoundEffects[0]);
                }
                Destroy(this.gameObject, 1.0f);
                break;
            case "Air Bomb(Clone)":
                if (ExplosionSound.isPlaying != false)
                {
                    return;
                }
                else
                {
                    ExplosionSound.PlayOneShot(ExplosionSoundEffects[1]);
                }
                break;
            case "Chain Explosion(Clone)":
                if (ExplosionSound.isPlaying != false)
                {
                    return;
                }
                else
                {
                    ExplosionSound.PlayOneShot(ExplosionSoundEffects[2]);
                }
                Destroy(this.gameObject, 1.0f);
                break;
        }
    }
}
