using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private EnemySpawner spawner;
    public float spawnInterval = 3;
    private float t;
    public int score = 0;

    public int maxHP = 10;
    public int currentHP;
    public int maxAmmo = 5;
    public int currentAmmo;

    public bool starPower = false;
    public float starPowerDuration = 0;
    public float starPowerBonus = 3f;

    public bool isAlive;

    public UnityEvent WaterPickup;




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

        WaterPickup.AddListener(AddAmmo);
    }

    private void EvenetDebug() => print("event called");

    private void Start()
    {
        AudioManager.instance.PauseSound("menutheme");
        AudioManager.instance.PlaySound("maintheme", true);
        currentHP = maxHP; 
        currentAmmo = maxAmmo;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(isAlive)
        {

            if(currentHP <= 0)
            {
                isAlive = false;
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
            t += Time.deltaTime;
            if (t > spawnInterval)
            {
                t = 0;
                spawner.SpawnRandomEnemey();
            }

        }
        else
        {
            starPower = false;
            currentAmmo = 0;

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
