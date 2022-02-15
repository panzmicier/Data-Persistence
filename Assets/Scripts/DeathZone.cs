using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] MainManager Manager;
    [SerializeField] AudioClip _crashSound;

    private void OnCollisionEnter(Collision other)
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(_crashSound, 1.0f);
        Destroy(other.gameObject);
        Manager.GameOver();
    }
}
