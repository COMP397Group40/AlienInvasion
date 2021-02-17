using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAmmo : MonoBehaviour
{
    public GameObject ammo;
    public new AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        ammo.SetActive(false);
        audio.Play();

    }
}
