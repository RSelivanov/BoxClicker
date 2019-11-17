using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioComponent : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        string[] sounds = { "Coin_01", "Coin_02", "Coin_03" } ;

        SoundManager.use.PlaySound(sounds[Random.Range(0, 1)]);
    }
}
