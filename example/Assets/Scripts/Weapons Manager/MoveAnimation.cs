using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public PlayerMove playerMove;
    public WeaponsMenager weaponsMenager;

    public Animator moveAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.isMove == true)
        {
            if (playerMove.isSprint == true)
            {
                if (weaponsMenager.currentWeaponInHands != null)
                {
                    moveAnimator.SetBool("weaponSprint", true);
                }
                else
                {
                    moveAnimator.SetBool("sprint", true);
                }
                moveAnimator.SetBool("move", false);
            }
            else
            {
                if (weaponsMenager.currentWeaponInHands != null)
                {
                    moveAnimator.SetBool("weaponSprint", false);
                }
                else
                {
                    moveAnimator.SetBool("sprint", false);
                }
                moveAnimator.SetBool("move", true);
            }
        }
        else
        {
            moveAnimator.SetBool("move", false);
            moveAnimator.SetBool("weaponSprint", false);
            moveAnimator.SetBool("sprint", false);
        }
    }
}
