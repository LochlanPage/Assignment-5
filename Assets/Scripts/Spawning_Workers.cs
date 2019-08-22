using UnityEngine;
using System.Collections;

public class Spawning_Workers : MonoBehaviour
{
    [SerializeField]
    GameObject worker;

    private bool waitDone = false;

    void Start()
    {
        Instantiate(worker, transform.position, transform.rotation);
        Instantiate(worker, transform.position, transform.rotation);
        Instantiate(worker, transform.position, transform.rotation);

        StartCoroutine(InitialWait());
    }

    private void Update()
    {
        if (waitDone == true)
        {
            float start = 1f;
            float timer = 5f;
            InvokeRepeating("SpawnWorker", start, timer);
            waitDone = false;
        }
    }

    public void SpawnWorker()
    {
        Instantiate(worker, transform.position, transform.rotation);
    }

    IEnumerator InitialWait()
    {
        yield return new WaitForSeconds(5);
        waitDone = true;
    }
}
