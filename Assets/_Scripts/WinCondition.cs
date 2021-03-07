using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // check if the object that triggers a collision is the player
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win");
        }
    }

}
