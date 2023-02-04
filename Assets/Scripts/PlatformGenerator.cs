using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    [Header("Fixed Distance")]
    [SerializeField] float platformDistance = 6f;
    [SerializeField] float sideDistance = 2.5f;

    GameObject LeftPosInstance;
    GameObject RightPosInstance;

    int platformCount = 4;
    int platformRowCount = 1;

    private void Start()
    {
        GeneratePlatforms();
    }

    private void GeneratePlatforms()
    {
        Vector3 leftPosition = transform.position + new Vector3(-sideDistance, -platformDistance, -1);
        Vector3 rightPosition = transform.position + new Vector3(sideDistance, -platformDistance, -1);
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
