using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    [SerializeField] float range;
    Vector3 destPoint;
    bool walkpointSet;


    //state change
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;


    //health
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float maxHealth = 10;
    private float currentHealth;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
        print(currentHealth);
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }



    private void Update()
    {

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if(!playerInSight && !playerInAttackRange) Patrol();
        if(playerInSight && !playerInAttackRange) Chase();
        if(playerInSight && playerInAttackRange) Attack();
    }


    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }



    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }



    void Attack()
    {

    }


    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }


    void OnMouseDown() {
        currentHealth -= Random.Range(0.5f, 1.5f);
        print(currentHealth);
        if (currentHealth <=0) {
            Destroy(agent);
        } else {
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

}
