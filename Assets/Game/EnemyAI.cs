using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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


    //shooting
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float bulletSpeed = 50;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }



    private void Update()
    {

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if(!playerInSight && !playerInAttackRange) Patrol();
        if(playerInSight && !playerInAttackRange) Chase();
        if(playerInSight && playerInAttackRange) Attack();

        if (currentHealth <= 0)
        {
            Die();
        }
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

        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        spawnPoint.LookAt(player.transform);


        GameObject bullet = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(spawnPoint.transform.forward * bulletSpeed);
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


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }


    public void Heal(float amount)
    {
        currentHealth += amount;
        print("heal is called");
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }



    private void Die()
    {
        Destroy(gameObject);
    }
}
