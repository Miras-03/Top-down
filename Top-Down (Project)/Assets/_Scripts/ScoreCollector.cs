using UnityEngine;

public sealed class ScoreCollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int score = Score.Instance.ScoreResult++;
        Debug.Log($"Score = {score}");

        AnimalHunger animalHunger = collision.gameObject.GetComponent<AnimalHunger>();
        if (animalHunger != null)
            animalHunger.FeedAnimal(25);
    }
}