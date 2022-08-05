using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float pipeSpeed = 0.55f;

    // Create an instance of the object
    public static PipeMovement m_Instance = null;
    //Singleton
    public static PipeMovement Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (PipeMovement)FindObjectOfType(typeof(PipeMovement));
            }
            return m_Instance;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.Instance.isGameEnded && GameManager.Instance.initDone)
        {
            transform.position += pipeSpeed * Time.deltaTime * Vector3.left;
        }
    }
}
