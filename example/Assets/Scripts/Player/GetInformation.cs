using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInformation : MonoBehaviour
{
    public bool shot;
    [Header("Player move")]
    public bool isMove;
    public bool isSprint;
    public bool isGround;

    [Header("For crosshair")]
    public float scaleForCrosshair;
    public float smouthTimeForCrosshair;

    public bool isScoped;
}
