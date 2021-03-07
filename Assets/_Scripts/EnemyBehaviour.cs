using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Animator animator;
    public HealthBarScreenSpaceController playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerHealth = FindObjectOfType<HealthBarScreenSpaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        navMeshAgent.SetDestination(player.position);

       
    }
    void OnTriggerEnter(Collider other)
    {
        // check if the object that triggers a collision is the player
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(10);

        }
    }


}
