using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public int maxHP = 10;
    public int currentHP;
    public int maxAmmo = 5;
    public int currentAmmo;

    public bool starPower = false;
    public float starPowerDuration = 0;
    public float starPowerBonus = 3f;


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
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

        if(currentHP < 0)
        {
            Debug.Log("GAME OVER");
        }

        if(starPowerDuration > 0)
        {
            starPowerDuration -= Time.deltaTime;
        }
        else
        {
            starPower = false;
        }

    }


    public void StarPower()
    {
        starPowerDuration += starPowerBonus;
        starPower = true;
    }

    public void AddAmmo()
    {
        if(currentAmmo == maxAmmo)
        {
            Debug.Log("Max Ammo");
        }
        else
        {
            currentAmmo++;
        }
    }
}
