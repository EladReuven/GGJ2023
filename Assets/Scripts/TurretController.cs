using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    [SerializeField] Transform turretLocation;
    [SerializeField] Transform turretHead;
    [SerializeField] Camera Player1Camera;
    Vector3 lookPos;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = turretLocation.position;
    }
    void Update()
    {
        mousePos = Input.mousePosition;

        FindLookPos();
        HandleRotation();
    }
    private void FindLookPos()
    {
        Ray ray = Player1Camera.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~0, QueryTriggerInteraction.Ignore))
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
