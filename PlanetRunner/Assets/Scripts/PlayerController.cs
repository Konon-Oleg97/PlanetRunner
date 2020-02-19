using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    float Sensitivity=20f;

    Rigidbody componentRigidbody;
    private float sidewaysSpeed=0f;
    private Vector2 touchLastPos;
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
    }


    private void FixedUpdate()
    {
        Vector3 forward = transform.forward * GameManager.instance.PlayerSpeed;
        componentRigidbody.velocity = forward;
        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * 2, Space.World);
        transform.Rotate(transform.up, sidewaysSpeed, Space.World);

        /*  Ray ray = new Ray(transform.position, -transform.up);
          RaycastHit Hit;

          if(Physics.Raycast(ray, out Hit,0.5f+0.01f,groundLayer))
          {
              componentRigidbody.AddForce(transform.up * 1000f);
          }*/
    }
}


