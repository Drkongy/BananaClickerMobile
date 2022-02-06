using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class particleClick : MonoBehaviour
{

    [SerializeField] ParticleSystem Particles;  // the particles system when clicking on the main banana

    public void particlePlay()
    {
        // plays the particle.
        Particles.Play();
    }



}
