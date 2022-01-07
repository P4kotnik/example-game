using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public GetInformation getInformation;
    public WeaponsMenager weaponsMenager;

    public Animator moveAnimator;

    // Update is called once per frame
    void Update()
    {
        if (getInformation.isMove == true)
        {
            if (getInformation.isSprint == true)
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

                if (weaponsMenager.isScoped())
                {
                    moveAnimator.SetBool("scope", true);
                }
                else
                {
                    moveAnimator.SetBool("scope", false);
                }
                moveAnimator.SetBool("move", true);
            }
        }
        else
        {
            moveAnimator.SetBool("move", false);
            moveAnimator.SetBool("weaponSprint", false);
            moveAnimator.SetBool("sprint", false);

            if (weaponsMenager.isScoped()) //do poprawy
            {
                moveAnimator.SetBool("scope", true);
            }
            else
            {
                moveAnimator.SetBool("scope", false);
            }
        }
    }
}
