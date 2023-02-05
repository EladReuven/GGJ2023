using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public bool canCreate = true;
    public Vector3 lastTransform;

    [Header("Platforms And Collectable Prefabs")]
    [SerializeField] GameObject[] Prefabs;


    [SerializeField] Transform targetObject;


    [Header("Fixed Distance")]
    [SerializeField] float platformDistance = 9.39f;
    [SerializeField] float sideDistance = 3.91f;

    Vector3 targetTransform;

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
        Instantiate(Prefabs[0], leftPosition, Quaternion.identity);
        Instantiate(Prefabs[0], midLeftPos, Quaternion.identity);
        Instantiate(Prefabs[0], MidRightPos, Quaternion.identity);
        Instantiate(Prefabs[0], rightPosition, Quaternion.identity);
        GeneratePlatforms(targetTransform + new Vector3(-sideDistance,- platformDistance,0),true);
    }

    public void GeneratePlatforms(Vector3 CharacteLoc,bool isSecond)
    {
        Vector3 leftPosition = CharacteLoc + new Vector3(-sideDistance, -platformDistance, 1);
        Vector3 midLeftPos = CharacteLoc + new Vector3(-sideDistance * 3, -platformDistance, 1);
        Vector3 MidRightPos = CharacteLoc + new Vector3(sideDistance, -platformDistance, 1);
        Vector3 rightPosition = CharacteLoc + new Vector3(sideDistance * 3, -platformDistance, 1);
        Vector3 MostrightPosition = CharacteLoc + new Vector3(sideDistance * 5, -platformDistance, 1);
        Vector3 MostLeft = CharacteLoc + new Vector3(-sideDistance * 5, -platformDistance, 1);

        UglyMonster(leftPosition, midLeftPos, MidRightPos, rightPosition, MostrightPosition, MostLeft);

        if (isSecond)
        {
            GeneratePlatforms(leftPosition, false);
        }
        else
        {
            lastTransform = leftPosition;
        }

        // Elad dont show anyone that knows C# iam emberaced 
        void UglyMonster(Vector3 leftPosition, Vector3 midLeftPos, Vector3 MidRightPos, Vector3 rightPosition, Vector3 MostrightPosition, Vector3 MostLeft)
        {
            int rangeCap = 3;
            int x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], leftPosition, Quaternion.identity);
            if (x == 2) rangeCap = 2;
            x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], midLeftPos, Quaternion.identity);
            if (x == 2) rangeCap = 2;
            x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], MidRightPos, Quaternion.identity);
            if (x == 2) rangeCap = 2;
            x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], rightPosition, Quaternion.identity);
            if (x == 2) rangeCap = 2;
            x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], MostrightPosition, Quaternion.identity);
            if (x == 2) rangeCap = 2;
            x = Random.Range(0, rangeCap);
            Instantiate(Prefabs[x], MostLeft, Quaternion.identity);
        }
    }
}
