using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoreTextShadow;

    // Create an instance of the object
    public static UIManager m_Instance = null;
    //Singleton
    public static UIManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (UIManager)FindObjectOfType(typeof(UIManager));
            }
            return m_Instance;
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        scoreTextShadow.text = GameManager.Instance.score.ToString();
    }
}
