using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutOfMap : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider player)
    {
        player.transform.position = new Vector3(12.33f, 1.68f, 0.46f);
    }
}
