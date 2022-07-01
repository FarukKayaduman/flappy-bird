using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public new Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity = 2.5f;

    public bool isGameEnded = false;

    // Create an instance of the object
    public static PlayerManager m_Instance = null;
    //Singleton
    public static PlayerManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
            }
            return m_Instance;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Add velocity if clicked
        if (Input.GetMouseButtonDown(0))
        {
            AddVelocityOnYAxis();
        }
    }

    private void AddVelocityOnYAxis()
    {
        rigidbody2D.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            // TO DO: Update score
        }
    }

}
