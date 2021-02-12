using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundController : MonoBehaviour
{
    public CharacterController cc;
    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.y > -3f && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.8f, 1);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
