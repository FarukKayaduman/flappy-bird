using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

    private void Start()
    {
        StartCoroutine(CreatePipe());
    }

    private IEnumerator CreatePipe()
    {
        while(!PlayerManager.Instance.isGameEnded)
        {
            Instantiate(pipePrefab, new Vector3(2.0f, Random.Range(0.25f, 0.75f), 0), Quaternion.identity);
            yield return new WaitForSeconds(1.4f);
        }
        if (PlayerManager.Instance.isGameEnded)
            StopCoroutine(CreatePipe());
    }
}
