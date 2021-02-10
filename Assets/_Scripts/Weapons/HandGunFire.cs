using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{
    public GameObject gun;
    public GameObject flash;
    public new AudioSource audio;
    public bool isFiring;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(isFiring == false)
                StartCoroutine(FiringGun());
        }

        IEnumerator FiringGun()
        {
            isFiring = true;
            gun.GetComponent<Animator>().Play("FiringGun");
            flash.SetActive(true);
            audio.Play();
            yield return new WaitForSeconds(0.05f);
            flash.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            gun.GetComponent<Animator>().Play("New State");
            isFiring = false;
        }
    }
}
