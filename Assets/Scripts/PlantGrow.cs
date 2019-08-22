using System.Collections;
using UnityEngine;

public class PlantGrow : MonoBehaviour
{
    [SerializeField]
    GameObject plant;

    void Start()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(5);
        plant.SetActive(true);
    }
}
