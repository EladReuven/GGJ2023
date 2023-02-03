using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGridCreation : MonoBehaviour
{
    public float xUnits = 6.0f;
    public float yUnits = 2.5f;

    [SerializeField] GameObject[] RockList;
    [SerializeField] Vector3 StartPostion;

    GameObject[,] RockGrid;
    
    void CreateGrid()
    {
        for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {

            }
        }
    }


}
