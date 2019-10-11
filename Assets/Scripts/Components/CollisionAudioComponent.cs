using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioComponent : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        string[] sounds = { "Coin_10", "Coin_11", "Coin_12" } ;

        //SoundManager.use.Play(sounds[Random.Range(0, 1)], 0.3f);
        SoundManager.use.PlaySound(sounds[Random.Range(0, 1)], 0.3f);
    }
}
