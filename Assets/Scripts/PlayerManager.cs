using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public new Rigidbody2D rigidbody2D;
    [SerializeField] private float velocity = 2.5f;

    public bool isGameEnded = false;
    public Button restartButton;

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
        if (Input.GetMouseButtonDown(0) && !PlayerManager.Instance.isGameEnded)
        {
            AddVelocityOnYAxis();
        }
    }

    private void AddVelocityOnYAxis()
    {
        rigidbody2D.velocity = Vector2.up * velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gate"))
        {
            GameManager.Instance.score++;
            UIManager.Instance.UpdateScoreText();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pipe") || collision.collider.CompareTag("Ground"))
        {
            GameManager.Instance.GameOver();
            if (collision.collider.CompareTag("Pipe"))
                collision.collider.gameObject.GetComponent<Collider2D>().enabled = false;
            restartButton.gameObject.SetActive(true);
        }
    }

}
