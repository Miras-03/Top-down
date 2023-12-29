using UnityEngine;
using UnityEngine.UI;

public sealed class AnimalHunger : MonoBehaviour
{
    [SerializeField] private Slider animalHunger;
    [SerializeField] private float maxHungerRange;

    private void Start()
    {
        animalHunger.maxValue = maxHungerRange;
        animalHunger.value = 0;
    }

    public void FeedAnimal(int amount)
    {
        if (animalHunger.value < maxHungerRange)
        {
            animalHunger.value += amount;
            Score.Instance.ScoreResult += 1;
        }
        else
            Destroy(gameObject);
    }
}