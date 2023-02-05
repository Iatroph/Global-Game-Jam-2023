using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip[] aClips;
    public float lifespan = 3f;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = aClips[Random.Range(0, aClips.Length - 1)];
        aSource.Play();

        Destroy(gameObject, lifespan);
    }
}