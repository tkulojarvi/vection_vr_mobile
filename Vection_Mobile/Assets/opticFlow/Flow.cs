using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    float move = 0;
    public float gap = 5;
    public float speed = 5;
    public float rotation = 0;
    float curSpeed = 0;
    float curRotation = 0;
    public float acceleration = 0;
    public float angularAcceleration = 0;
    public float linearTime = 1.0f;
    public float accelerationTime = 0.0f;
    float curAccelerationTime = 0.0f;
    public float randomAccelerationSwing = 0.0f;
    public float decelerationTime = 0.0f;
    float maxSpeed = 0;
    float maxRotation = 0;
    float timer = 0;
    Vector3 startingPos;
    private void Start()
    {
        startingPos = transform.position;
        curSpeed = speed;
        curRotation = rotation;
        curAccelerationTime = accelerationTime;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < linearTime){
            curSpeed = speed;
            curRotation = rotation;
            curAccelerationTime = accelerationTime;
        }
        if (timer >= linearTime && timer < linearTime + curAccelerationTime)
        {
            curSpeed += acceleration * Time.deltaTime;
            curRotation += angularAcceleration * Time.deltaTime;
            maxSpeed = curSpeed;
            maxRotation = curRotation;
        }
        else if (timer >= linearTime + curAccelerationTime && timer < linearTime + curAccelerationTime + decelerationTime)
        {
            curSpeed = Mathf.Lerp(maxSpeed, speed, (timer - linearTime - curAccelerationTime) / decelerationTime);
            curRotation = Mathf.Lerp(maxRotation, rotation, (timer - linearTime - curAccelerationTime) / decelerationTime);
        }
        else if (timer >= linearTime + curAccelerationTime + decelerationTime) {
            timer -= linearTime + curAccelerationTime + decelerationTime;
            curAccelerationTime = accelerationTime + Random.Range(-randomAccelerationSwing, randomAccelerationSwing);
        }
        move = Mathf.Repeat(move + curSpeed * Time.deltaTime, gap);
        transform.position = startingPos + Vector3.forward * move;
        transform.Rotate(0,0,curRotation * Time.deltaTime, Space.World);
    }
}
