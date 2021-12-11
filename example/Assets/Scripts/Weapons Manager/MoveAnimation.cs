using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public PlayerMove playerMove;
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
            moveAnimator.Play("Move");
        }
    }
}
