using System;
using System.Collections;
using UnityEngine;

public sealed class SpawnManager : MonoBehaviour
{
    private ObjectPooler pooler;

    private const int xBorder = 25;
    private const int xRange = 15;
    private const int zRange = 10;
    private const int intervalTime = 2;

    private void Awake() => pooler = GetComponent<ObjectPooler>();

    private void Start()
    {
        pooler.CreateObjects(transform);
        StartCoroutine(WaitForDelayAndSpawn());
    }

    private IEnumerator WaitForDelayAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            int randSide = UnityEngine.Random.Range(0, 2);

            if (randSide == 0)
                GenerateTopAndInstantiate();
            else
                GenerateSideAndInstantiate();
        }
    }

    private void GenerateTopAndInstantiate()
    {
        int randX = UnityEngine.Random.Range(-xRange, xRange);
        const int zPos = -10;
        Vector3 randPos = new Vector3(randX, 0, zPos);
        pooler.ReleaseObject(GenerateEnemyTag(), randPos, Quaternion.identity);
    }

    private void GenerateSideAndInstantiate()
    {
        int[] xPosition = { -xBorder, xBorder };
        int randX = UnityEngine.Random.Range(0,2);
        int randZ = UnityEngine.Random.Range(-1, zRange);
        int rotationValue = randX == 0 ? 90 : -90;

        Vector3 randPos = new Vector3(xPosition[randX], 0, randZ);
        Vector3 randRotation = new Vector3(0,rotationValue,0);
        Quaternion q = Quaternion.Euler(randRotation);
        pooler.ReleaseObject(GenerateEnemyTag(), randPos, q);
    }

    private string GenerateEnemyTag()
    {
        EnemyType[] types = { EnemyType.Fox, EnemyType.Horse, EnemyType.Moose };
        int randIndex = UnityEngine.Random.Range(0, types.Length);
        return types[randIndex].ToString();
    }

    private enum EnemyType
    {
        Fox,
        Horse,
        Moose
    }
}