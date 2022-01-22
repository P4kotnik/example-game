using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDMenager : MonoBehaviour
{
    public TextMeshProUGUI bullets;
    public TextMeshProUGUI magazines;

    public WeaponsMenager weaponsMenager;

    // Update is called once per frame
    void Update()
    {
        bullets.text = weaponsMenager.currentMagazineCapacity + "|" + weaponsMenager.magazineCapacity;
        magazines.text = weaponsMenager.currentNumberOfMagazines.ToString();
    }
}
