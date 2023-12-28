using UnityEngine;

public sealed class OutOfBoundDestroy : MonoBehaviour
{
    private const int topBound = -15;
    private const int downBound = 20;

    private void FixedUpdate() => CheckOrDestroy();

    private void CheckOrDestroy()
    {
        float currentPos = transform.position.z;
        if (currentPos < topBound)
            Destroy(gameObject);
        else if (currentPos > downBound)
        {
            Destroy(gameObject);
            TerminateGame();
        }
    }

    private void TerminateGame()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}