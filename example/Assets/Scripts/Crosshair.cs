using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform rectTransform;
    public WeaponsMenager weaponsMenager;

    [Range(30f, 250)]
    public float defaultSize = 50f;
    [Range(60f, 250)]
    public float maxSize = 110f;

    public float currentSize;
    public float scale = 1f;

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
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            scale = 2f;
            wait = true;
            waitTime = 0.05f;
        }
        else if (weaponsMenager.isShot)
        {
            scale = 1.5f;
            wait = true;
            waitTime = 0.05f;
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
            }
        }

        if (currentSize <= maxSize && currentSize >= defaultSize)
        {
            currentSize = Mathf.Lerp(currentSize, currentSize * scale, Time.deltaTime * 2);
        }
        //crouching
        rectTransform.sizeDelta = new Vector2(currentSize, currentSize);
    }
}
