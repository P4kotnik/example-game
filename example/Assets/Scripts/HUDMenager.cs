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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bullets.text = weaponsMenager.currentMagazineCapacity + "|" + weaponsMenager.magazineCapacity;
        magazines.text = weaponsMenager.currentNumberOfMagazins.ToString();
    }
}
