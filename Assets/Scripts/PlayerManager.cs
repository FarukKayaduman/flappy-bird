using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Button restartButton;

    [SerializeField] private AudioClip pointClip;

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
            AudioManager.Instance.PlayAudio(pointClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.Instance.isGameEnded)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                GameManager.Instance.GameOver();
                restartButton.gameObject.SetActive(true);
            }
            else if (collision.collider.CompareTag("Pipe"))
            {
                collision.collider.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.collider.gameObject.transform.parent.GetChild(1).gameObject.SetActive(false);
                collision.collider.gameObject.transform.parent.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;

                GameManager.Instance.GameOver();
                restartButton.gameObject.SetActive(true);
            }
        }
    }
}
