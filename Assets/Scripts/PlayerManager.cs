using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
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
