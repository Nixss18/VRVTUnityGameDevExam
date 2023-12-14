using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform player;

    // [SerializedField] private float timer = 5;


    void Update()
    {
        enemy.SetDestination(player.position);
    }


}
