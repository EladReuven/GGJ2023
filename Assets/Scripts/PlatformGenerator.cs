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

    Queue<GameObject> Instaces;

    int platformCount = 4;
    int platformRowCount = 1;

    Vector3 targetTransform;

    private void Update()
    {
        targetTransform = targetObject.position;
    }

    private void GenerateThree(Vector3 mostLeftVector)
    {
        Vector3 leftPosition = mostLeftVector + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 Mid = mostLeftVector + new Vector3(sideDistance, -platformDistance, 1);
        Vector3 rightPostion = mostLeftVector + new Vector3(sideDistance*3, -platformDistance, 1);
        Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        Instantiate(platformPrefab, Mid, Quaternion.identity);
        Instantiate(platformPrefab, rightPostion, Quaternion.identity);
        GeneratePlatforms(leftPosition);
        GeneratePlatforms(rightPostion);
    }
    private void GeneratePlatforms(Vector3 mostLeftVector)
    {
        Vector3 leftPosition = mostLeftVector + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 rightPosition = mostLeftVector + new Vector3(sideDistance, -platformDistance, 1);
        LeftPosInstance = Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        RightPosInstance = Instantiate(platformPrefab, rightPosition, Quaternion.identity);
    }

    [ContextMenu("Generate")]
    public void GeneratePlatforms()
    {
        Vector3 leftPosition = targetTransform + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 rightPosition = targetTransform + new Vector3(sideDistance, -platformDistance, 1);
        LeftPosInstance = Instantiate(platformPrefab, leftPosition, Quaternion.identity);
        RightPosInstance = Instantiate(platformPrefab, rightPosition, Quaternion.identity);

        if (canCreate)
        {
            canCreate = false;
            for (int i = 0; i < 2; i++)
            {
                GenerateThree(leftPosition);
            }
        }
    }
}
