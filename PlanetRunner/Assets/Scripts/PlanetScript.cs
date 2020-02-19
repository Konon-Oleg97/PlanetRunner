using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{

    HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    Rigidbody componentRigibody;

    private void Start()
    {
        componentRigibody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody body in affectedBodies)
        {
            Vector3 directionToPlanet = (transform.position - body.position).normalized;

            float distance = (transform.position - body.position).magnitude;
            float strength = body.mass * componentRigibody.mass / (distance*distance);
            body.AddForce(directionToPlanet *strength);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody!=null)
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Remove(other.attachedRigidbody);
        }
    }
}
