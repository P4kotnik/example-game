using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform rectTransform;
    public WeaponsMenager weaponsMenager;
    public PlayerMove playerMove;

    [Range(30f, 250)]
    public float defaultSize = 50f;
    [Range(60f, 250)]
    public float maxSize = 100f;

    public float currentSize;
    float scale = 1f;

    bool wait;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentSize = defaultSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMove == true)
        {
            scale = 2f;
            wait = true;
            waitTime = 0.1f;
            if (currentSize >= maxSize)
            {
                scale = 1f;
            }
        }
        else if (weaponsMenager.isShot)
        {
            scale = weaponsMenager.currentWeaponInHands.GetComponent<WeaponInfo>().scaleForCrosshair;
            wait = true;
            waitTime = weaponsMenager.currentWeaponInHands.GetComponent<WeaponInfo>().waitTimeForCrosshair;
        }
        else
        {
            if (wait == true)
            {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                {
                    wait = false;
                }
            }
            else
            {
                scale = 0.5f;
                if (currentSize <= defaultSize)
                {
                    scale = 1f;
                }
            }
        }

        if (currentSize <= maxSize && currentSize >= defaultSize)
        {
            currentSize = Mathf.Lerp(currentSize, currentSize * scale, Time.deltaTime * 2);
        }
        else if (currentSize > maxSize)
        {
            currentSize = maxSize;
        }
        else if (currentSize < defaultSize)
        {
            currentSize = defaultSize;
        }

        rectTransform.sizeDelta = new Vector2(currentSize, currentSize);
    }
}
