using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class particleClick : MonoBehaviour
{

    [SerializeField] ParticleSystem Particles;

    public void particlePlay()
    {

        Particles.Play();
    }



}
