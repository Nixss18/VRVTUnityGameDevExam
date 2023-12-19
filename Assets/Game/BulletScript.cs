using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().TakeDamage(1);
            Destroy(gameObject);
        }

        if (other.CompareTag("Map"))
        {
            Destroy(gameObject);
        }
    }
}
