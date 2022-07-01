using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PipeManager pipeManager;

    private bool initDone = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && PlayerManager.Instance.isGameEnded == false && initDone == false)
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
}
