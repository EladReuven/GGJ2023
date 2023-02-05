using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class AmmoAmount : MonoBehaviour
{
    int ammoAmount = GameManager.Instance.maxAmmo;

    [SerializeField] Image[] ammo;

    private void Start()
    {
        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        for(int i = 0; i < ammo.Length; i++)
        {
            if(i < ammoAmount)
            {
                ammo[i].enabled = true;
            }
            else
            {
                ammo[i].enabled = false;

            }
        }
    }

}
