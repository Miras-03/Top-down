using System.Collections;
using UnityEngine;

public sealed class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] animals;

    private const int xRange = 15;

    private void Start() => StartCoroutine(SpawnWithDelay());

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            GenerateAndInstantiate();
            yield return new WaitForSeconds(3);
        }
    }

    private void GenerateAndInstantiate()
    {
        int index = Random.Range(0, animals.Length);
        int randX = Random.Range(-xRange, xRange);
        Vector3 randPos = new Vector3(randX, 0, transform.position.z);
        Instantiate(animals[index], randPos, Quaternion.identity);
    }
}