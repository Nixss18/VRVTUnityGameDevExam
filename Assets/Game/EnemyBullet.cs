using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("RealPlayer"))
        {
            print("destroy");

            other.GetComponent<PlayerHealthBar>().TakeDamage(1);
            Destroy(gameObject);
        }

    }
}
