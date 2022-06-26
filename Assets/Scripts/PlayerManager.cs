using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float yVelocity = 2.5f;


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddVelocityOnYAxis();
        }
    }

    private void AddVelocityOnYAxis()
    {
        rigidbody.velocity = Vector2.up * yVelocity;
    }

}
