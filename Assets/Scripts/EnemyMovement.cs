using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // The player's position
    private NavMeshAgent navMeshAgent; // The NavMeshAgent component of the enemy
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            navMeshAgent.SetDestination(player.position); // Set the destination of the NavMeshAgent to the player's position
        }
    }
}
