using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;


    void Update()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Ensure we only rotate around the Y-axis

        bulletSpawnPoint.forward = cameraForward;

        // Position bulletSpawnPoint slightly in front of the camera
        float offset = 1.0f; // You can adjust this value to fit your needs
        bulletSpawnPoint.position = Camera.main.transform.position + offset * cameraForward;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
