using System.Collections;
using UnityEngine;

public sealed class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] animals;

    private const int xBorder = 25;

    private const int xRange = 15;
    private const int zRange = 10;

    private const int intervalTime = 2;

    private void Start() => StartCoroutine(WaitForDelayAndSpawn());

    private IEnumerator WaitForDelayAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            int randNum = Random.Range(0, 2);

            if (randNum == 0)
                GenerateTopAndInstantiate();
            else
                GenerateSideAndInstantiate();
        }
    }

    private void GenerateTopAndInstantiate()
    {
        int index = Random.Range(0, animals.Length);
        int randX = Random.Range(-xRange, xRange);
        const int spawnPoint = -10;
        Vector3 randPos = new Vector3(randX, 0, spawnPoint);
        Instantiate(animals[index], randPos, Quaternion.identity);
    }

    private void GenerateSideAndInstantiate()
    {
        int[] xPosition = { -xBorder, xBorder };
        int index = Random.Range(0, animals.Length);
        int randX = Random.Range(0,2);
        int randZ = Random.Range(-1, zRange);
        int rotationValue = randX == 0 ? 90 : -90;

        Vector3 randPos = new Vector3(xPosition[randX], 0, randZ);
        Vector3 randRotation = new Vector3(0,rotationValue,0);
        Quaternion q = Quaternion.Euler(randRotation);
        Instantiate(animals[index], randPos, q);
    }
}