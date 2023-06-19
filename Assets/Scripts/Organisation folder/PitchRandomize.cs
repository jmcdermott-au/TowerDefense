using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchRandomize : MonoBehaviour
{
    public AudioSource audioSource;

    public void RandomizePitch()
    {
        audioSource.pitch = Random.Range(0.8f, 2f);
    }
}
