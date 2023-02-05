using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHPUI : MonoBehaviour
{
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI hp;

    private void Update()
    {
        hp.text = GameManager.Instance.currentHP.ToString();
        ammo.text = GameManager.Instance.currentAmmo.ToString();
    }
}
