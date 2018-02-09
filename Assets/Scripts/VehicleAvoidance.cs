using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAvoidance : MonoBehaviour
{

    public float speed = 20;
    public float mass = 5;
    public float force = 50;
    public float minimumDistToAvoid = 20;
    private float curSpeed;
    private Vector3 targetPoint;

	void Start ()
    {
        mass = 5;
        targetPoint = Vector3.zero;
	}
	
    void OnGUI()
    {
        GUILayout.Label("Click anywhere to move the vehicle.");
    }

	void Update ()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0)&&Physics.Raycast(ray, out hit, 100))
        {
            targetPoint = hit.point;
        }

        Vector3 dir = (targetPoint - transform.position);
        dir.Normalize();

        AvoidObstacles(ref dir);	

        if(Vector3.Distance(targetPoint,transform.position)<3)
        {
            return;
        }

        curSpeed = speed * Time.deltaTime;

        var rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5 * Time.deltaTime);

        transform.position += transform.forward * curSpeed;

	}

    public void AvoidObstacles(ref Vector3 dir)
    {
        RaycastHit hit;

        int layerMask = 1 << 8;

        if(Physics.Raycast(transform.position,transform.forward, out hit, minimumDistToAvoid, layerMask))
        {
            Vector3 hitNoraml = hit.normal;
            hitNoraml.y = 0.5f;
            dir = transform.forward + hitNoraml * force;
        }
    }

}
