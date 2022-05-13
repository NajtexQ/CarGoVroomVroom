using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarEngineSound : MonoBehaviour
{

    public static CarEngineSound instance;
    public Rigidbody rb;

    public AudioSource engineSound;

    public float constant = 1f;
    public float divider = 10f;
    void Awake()
    {
        instance = this;
        engineSound = GetComponent<AudioSource>();

        AudioManager.instance.Stop("Music");
    }

    public void PlayEngineSound()
    {
        engineSound.Play();
    }

    public void StopEngineSound()
    {
        engineSound.Stop();
    }

    void Update()
    {
        engineSound.pitch = constant + (rb.velocity.magnitude / divider);
    }
}
