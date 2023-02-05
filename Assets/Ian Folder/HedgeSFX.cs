using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeSFX : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip[] aClips;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = aClips[Random.Range(0, aClips.Length - 1)];
        aSource.Play();
    }
}
