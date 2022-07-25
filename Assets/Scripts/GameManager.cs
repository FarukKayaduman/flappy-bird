using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PipeManager pipeManager;

    public bool initDone = false;

    public int score = 0;

    // Create an instance of the object
    public static GameManager m_Instance = null;
    //Singleton
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return m_Instance;
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PlayerManager.Instance.isGameEnded && !initDone)
        {
            InitializeGameAtStart();
            initDone = true;
        }
    }

    private void InitializeGameAtStart()
    {
        PlayerManager.Instance.rigidbody2D.gravityScale = 1.0f;
        pipeManager.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        PlayerManager.Instance.isGameEnded = true;
    }
}
