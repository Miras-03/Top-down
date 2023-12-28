using System.Collections;
using UnityEngine;

public sealed class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] animals;

    private const int xRange = 15;
    private const int startDelay = 1;
    private const int endDelay = 2;

    private void Start() => InvokeRepeating(nameof(GenerateAndInstantiate), startDelay, endDelay);

    private void GenerateAndInstantiate()
    {
        int index = Random.Range(0, animals.Length);
        int randX = Random.Range(-xRange, xRange);
        Vector3 randPos = new Vector3(randX, 0, transform.position.z);
        Instantiate(animals[index], randPos, Quaternion.identity);
    }
}