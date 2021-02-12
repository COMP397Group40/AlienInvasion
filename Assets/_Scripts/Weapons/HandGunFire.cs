using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{
    public GameObject gun;
    public GameObject flash;
    public new AudioSource audio;
    public bool isFiring;
    public float damage = 10f;
    public float range = 100f;
    public Camera PlayerCamera;

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
            Shoot();
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

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

        }
    }
}
