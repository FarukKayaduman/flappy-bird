using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed = 0.55f;

    private void Start()
    {
        Destroy(gameObject, 6.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += pipeSpeed * Time.deltaTime * Vector3.left;
    }
}
