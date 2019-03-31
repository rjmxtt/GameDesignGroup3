using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource mob2;


    void Start()
    {
        mob2 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        mob2.Play();
    }

}
