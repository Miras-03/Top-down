using UnityEngine;

public sealed class AnimalBoundDestroy : OutOfBoundDestroy
{
    private const int bound = 30;

    public override void CheckOrDestroy()
    {
        float currentXPos = Mathf.Abs(transform.position.x);
        float currentZPos = Mathf.Abs(transform.position.z);
        if (currentZPos > bound || currentXPos > bound)
        {
            Destroy(gameObject);
            if (LiveCount.Instance.Count > 0)
                DecreaseAndDisplayLive();
            else
                TerminateGame();
        }
    }

    private void DecreaseAndDisplayLive()
    {
        LiveCount.Instance.Count--;
        Debug.Log(LiveCount.Instance.Count);
    }

    private void TerminateGame()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}