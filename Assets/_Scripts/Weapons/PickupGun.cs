using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    public GameObject gun;
    public GameObject pickedGun;
    public new AudioSource audio;

    void OnTriggerEnter (Collider other)
    {
        pickedGun.SetActive(true);
        gun.SetActive(false);
        audio.Play();
        
    }

}
