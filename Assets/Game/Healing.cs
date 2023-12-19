using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("heal");
            other.GetComponent<EnemyAI>().Heal(1);
            Destroy(gameObject);
        }
    }
}
