using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFollowing : MonoBehaviour
{

    public Path path;
    public float speed = 20;
    public float mass = 5;
    public bool isLooping = true;
    private float curSpeed;

    private int curPathIndex;
    private float pathLnegth;
    private Vector3 targetPoint;

    Vector3 velocity;

    void Start()
    {
        pathLnegth = path.Length;
        curPathIndex = 0;
        velocity = transform.forward;
    }

    void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(curPathIndex);

        if (Vector3.Distance(transform.position, targetPoint) < path.Radius)
        {
            if (curPathIndex < pathLnegth - 1)
            {
                curPathIndex++;
            }

            else
            {
                if (isLooping)
                {
                    curPathIndex = 0;
                }

                else
                {
                    return;
                }
            }  
        }

        if(curPathIndex >= pathLnegth) // 벗어나지 않게 하기 위해 설정함
        {
            return;
        }

        if(curPathIndex >= pathLnegth-1&& !isLooping)
        {
            velocity += Steer(targetPoint, true);
        }

        else
        {
            velocity += Steer(targetPoint);    
        }

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    public Vector3 Steer(Vector3 target, bool bFinalPoint = false)
    {
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;
        desiredVelocity.Normalize();

        if (bFinalPoint && dist < 10)
        {
            desiredVelocity *= (curSpeed * (dist / 10));
        }

        else
        {
            desiredVelocity *= curSpeed;
        }

        Vector3 steeringForce = desiredVelocity - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;
    }

}