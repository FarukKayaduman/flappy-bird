using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    
    [SerializeField] private float velocity = 2.3f;

    [SerializeField] private AudioClip wingClip;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Add velocity if clicked
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.isGameEnded == false)
        {
            AddVelocityOnYAxis();
            AudioManager.Instance.PlayAudio(wingClip);

        }
    }

    private void AddVelocityOnYAxis()
    {
        rigidbody2D.velocity = Vector2.up * velocity;
    }
}
