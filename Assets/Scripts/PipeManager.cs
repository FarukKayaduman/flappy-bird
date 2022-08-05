using System.Collections;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

    private bool pipeCoroutineStarted;

    private void Update()
    {
        if (GameManager.Instance.initDone && !pipeCoroutineStarted)
        {
            StartCoroutine(CreatePipe());
            pipeCoroutineStarted = true;
        }
    }

    private IEnumerator CreatePipe()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(pipePrefab, new Vector3(2.0f, Random.Range(0.25f, 0.75f), 0), Quaternion.identity);
            yield return new WaitForSeconds(1.4f);
        }
        StopCoroutine(CreatePipe());
    }
}
