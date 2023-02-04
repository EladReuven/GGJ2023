using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public bool canCreate = true;


    [Header("Platforms And Collectable Prefabs")]
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject obstclePrefab;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject deshenPrefab;
    [SerializeField] GameObject powerupPrefab;

    [SerializeField] Transform targetObject;


    [Header("Fixed Distance")]
    [SerializeField] float platformDistance = 9.39f;
    [SerializeField] float sideDistance = 3.91f;

    GameObject LeftPosInstance;
    GameObject RightPosInstance;

    int platformCount = 4;
    int platformRowCount = 1;

    Vector3 targetTransform;

    List<Vector3> instances;

    private void Update()
    {
        targetTransform = targetObject.position;
    }


    [ContextMenu("Generate")]
    public void GeneratePlatformsInitial()
    {
        Vector3 leftPosition = targetTransform + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 midLeftPos = targetTransform + new Vector3(-sideDistance * 3, -platformDistance, 1);
        Vector3 MidRightPos = targetTransform + new Vector3(sideDistance, -platformDistance, 1);
        Vector3 rightPosition = targetTransform + new Vector3(sideDistance * 3, -platformDistance, 1);
        Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        Instantiate(platformPrefab, midLeftPos, Quaternion.identity);
        Instantiate(platformPrefab, MidRightPos, Quaternion.identity);
        Instantiate(platformPrefab, rightPosition, Quaternion.identity);
        GeneratePlatforms(targetTransform + new Vector3(-sideDistance,- platformDistance,0),true);
    }
    public void GeneratePlatforms(Vector3 CharacteLoc,bool isSecond)
    {
        Vector3 leftPosition = CharacteLoc + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 midLeftPos = CharacteLoc + new Vector3(-sideDistance * 3, -platformDistance, 1);
        Vector3 MidRightPos = CharacteLoc + new Vector3(sideDistance, -platformDistance, 1);
        Vector3 rightPosition = CharacteLoc + new Vector3(sideDistance * 3, -platformDistance, 1);
        Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        Instantiate(platformPrefab, midLeftPos, Quaternion.identity);
        Instantiate(platformPrefab, MidRightPos, Quaternion.identity);
        Instantiate(platformPrefab, rightPosition, Quaternion.identity);
        if (isSecond)
        {
            GeneratePlatforms(leftPosition, false);
        }
    }
}
