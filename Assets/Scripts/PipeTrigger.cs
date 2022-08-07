using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.localPosition = new Vector3(2, Random.Range(-0.2f, 0.75f), 0);
    }
}
