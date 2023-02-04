using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
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

    private void Update()
    {
        targetTransform = targetObject.position;
    }

    [ContextMenu("Generate")]
    public void GeneratePlatforms()
    {
        Vector3 leftPosition = targetTransform + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 rightPosition = targetTransform + new Vector3(sideDistance, -platformDistance, 1);
        LeftPosInstance = Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        RightPosInstance = Instantiate(platformPrefab, rightPosition, Quaternion.identity);

        platformRowCount++;

        if (platformRowCount <= platformCount)
        {
            PlatformGenerator leftGenerator = LeftPosInstance.GetComponent<PlatformGenerator>();
            PlatformGenerator rightGenerator = RightPosInstance.GetComponent<PlatformGenerator>();
            if (leftGenerator)
            {
                leftGenerator.GeneratePlatforms();
            }
            if (rightGenerator)
            {
                rightGenerator.GeneratePlatforms();
            }
        }
    }
}
