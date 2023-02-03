using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHP = 10;
    public int currentHP;
    public int maxAmmo = 10;
    public int currentAmmo;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        currentHP = maxHP; 
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
