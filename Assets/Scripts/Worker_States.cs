using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Worker_States : MonoBehaviour
{
    private bool sleep = false;
    private bool seed = false;
    private bool farm = false;
    private bool sleeping = true;
    private bool sleepTime = false;

    [SerializeField]
    GameObject seedObject;

    [SerializeField]
    GameObject plantObject;

    [SerializeField]
    ParticleSystem sleepingParticle;

    NavMeshAgent worker;

    private GameObject Top;
    private GameObject Down;
    private GameObject Left;
    private GameObject Right;

    private void Awake()
    {
        Top = GameObject.FindGameObjectWithTag("Top");
        Down = GameObject.FindGameObjectWithTag("Down");
        Left = GameObject.FindGameObjectWithTag("Left");
        Right = GameObject.FindGameObjectWithTag("Right");
    }
    void Start()
    {
        worker = GetComponent<NavMeshAgent>();
        Seed();
    }

    void Update()
    {
        if (seed == true)
        {
            if (Vector3.Distance(transform.position, GameObject.Find("SeedLocation").transform.position) < 3)
            {
                seedObject.SetActive(true);
                Farming();
            }
        }

        if (farm == true)
        {
            if (seedObject.activeSelf == true)
            {
                if (Vector3.Distance(transform.position, worker.destination) < 3)
                {
                    Instantiate(plantObject, worker.destination, Quaternion.identity);
                    seedObject.SetActive(false);
                }
            }

            else if (seedObject.activeSelf == false)
            {
                Sleeping();
            }
        }

        if (sleep == true)
        {
            if (Vector3.Distance(transform.position, worker.destination) < 3)
            {
                if (sleeping)
                {
                    StartCoroutine(SleepTime());
                }

                if (sleepTime != true)
                {
                    Seed();
                    sleeping = true;
                }
            }
        }
    }

    private void Seed()
    {
        sleep = false;
        seed = true;
        farm = false;
        worker.SetDestination(GameObject.Find("SeedLocation").transform.position);
    }

    private void Farming()
    {
        sleep = false;
        seed = false;
        farm = true;

        float x = Random.Range(Left.transform.position.x, Right.transform.position.x);
        float z = Random.Range(Down.transform.position.z, Top.transform.position.y);

        worker.SetDestination(new Vector3(x, transform.position.y, z));
    }

    private void Sleeping()
    {
        sleep = true;
        seed = false;
        farm = false;
        worker.SetDestination(GameObject.Find("Spread").transform.position);
    }

    IEnumerator SleepTime()
    {
        sleepTime = true;
        Instantiate(sleepingParticle, transform.position, Quaternion.identity);
        sleeping = false;
        yield return new WaitForSeconds(5);
        sleepTime = false;
    }
}