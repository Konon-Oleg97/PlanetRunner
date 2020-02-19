using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMenu : MonoBehaviour
{
    Rigidbody componentRigidbody;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 forward = transform.forward * 4f;
        componentRigidbody.velocity = forward;

    }
}
