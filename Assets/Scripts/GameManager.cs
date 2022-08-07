using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PipeManager pipeManager;

    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip hitClip;

    public bool isGameEnded = false;

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

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isGameEnded && !initDone)
        {
            InitializeGameAtStart();
        }
    }

    private void InitializeGameAtStart()
    {
        PlayerManager.Instance.GetComponent<Rigidbody2D>().gravityScale = 0.75f;
        pipeManager.gameObject.SetActive(true);
        initDone = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Instance.isGameEnded = true;
        AudioManager.Instance.PlayAudio(dieClip);
        AudioManager.Instance.PlayAudio(hitClip);
    }
}
