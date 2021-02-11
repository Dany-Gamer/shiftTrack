using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.5f;
    float destination = 846f;
    float initPos;

    private void Awake()
    {
        initPos = transform.position.x;
    }

    public void BallMovement()
    {
        LeanTween.moveX(gameObject,destination,movementSpeed);
    }

    public void ResetPos()
    {
        gameObject.transform.position =  new Vector2(initPos, transform.position.y);
    }
}
