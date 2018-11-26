using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public AudioClip impact;
    private AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.relativeVelocity.x > 4 || theCollision.relativeVelocity.x < -4 || theCollision.relativeVelocity.z < -4 || theCollision.relativeVelocity.z > 4) ///based on if speed of collision
            //best place to put Audio? HELP
            source.PlayOneShot(impact, 1F);
        else 
        {
            source.PlayOneShot(impact, .2f);
        }
        

    }
}
