using UnityEngine;

public sealed class ScoreCollector : MonoBehaviour
{
    private void OnCollisionEnter()
    {
        int score = Score.Instance.ScoreResult++;
        Debug.Log($"Score = {score}");
    }
}
