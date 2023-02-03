using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    [Header("Base")]
    [SerializeField] Transform turretLocation;
    [SerializeField] Transform turretHead;

    [Header("Aiming")]
    [SerializeField] Camera Player1Camera;

    [Header("Shooting")]
    [SerializeField] Transform bulletSpawnLocation;
    [SerializeField] GameObject bulletPrefab;
    List<GameObject> bulletPool;
    int bulletPoolSize = 10;

    Vector3 lookPos;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new List<GameObject>();
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bulletPool.Add(bullet);
            bullet.SetActive(false);
        }
    }
    void Update()
    {
        mousePos = Input.mousePosition;

        FindLookPos();
        HandleRotation();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.currentHP--;
        }
    }

    private void Shoot()
    {
        if(GameManager.Instance.currentAmmo > 0)
        {
            GameObject bullet = GetPooledBullet();
            bullet.transform.position = bulletSpawnLocation.position;
            bullet.transform.rotation = bulletSpawnLocation.rotation;
            Debug.Log(bulletSpawnLocation.localRotation);
            bullet.SetActive(true);
            GameManager.Instance.currentAmmo -= 1;
        }
        else
        {
            Debug.Log("NO AMMO");
        }
    }

    GameObject GetPooledBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                return bulletPool[i];
            }
        }
        return null;
    }

    private void FindLookPos()
    {
        Ray ray = Player1Camera.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Ignore)) //thx chatgpt
        {
            if (hit.collider.CompareTag("AimWall"))
            {
                // Do something with the hit information
                Vector3 lookP = hit.point;
                lookP.z = transform.position.z;
                lookPos = lookP;
            }
        }
    }


    private void HandleRotation()
    {
        Vector3 directionToLook = lookPos - turretHead.transform.position;
        float rotZ = Mathf.Atan2(directionToLook.y, directionToLook.x) * Mathf.Rad2Deg;
        turretHead.transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
