using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Sounds : MonoBehaviour
{
    public AudioSource enemy;
    public AudioSource house; 
    public AudioSource Cesped;
    public AudioClip soundAtack;
    public float volume = 1;


    private void OnTriggerEnter(Collider other)
    {
        enemy.PlayOneShot(soundAtack, volume);
    }
}
