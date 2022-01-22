using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform rectTransform;

    public GetInformation getInformation;
    public GameObject crosshairObject;

    [Range(30f, 250)]
    public float defaultSize = 75f;
    [Range(60f, 250)]
    public float maxSize = 125f;

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
        CrosshairEnabled();

        if (getInformation.isMove == true)
        {
            scale = 2f;
            wait = true;
            waitTime = 0.05f;
            if (currentSize >= maxSize)
            {
                scale = 1f;
            }
        }
        else if (getInformation.shot)
        {
            scale = getInformation.scaleForCrosshair;
            waitTime = getInformation.smouthTimeForCrosshair;

            wait = true;
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
                scale = 0.25f;
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

    void CrosshairEnabled()
    {
        if (getInformation.isSprint || getInformation.isScoped)
        {
            crosshairObject.SetActive(false);
        }
        else
        {
            crosshairObject.SetActive(true);
        }
    }
}
