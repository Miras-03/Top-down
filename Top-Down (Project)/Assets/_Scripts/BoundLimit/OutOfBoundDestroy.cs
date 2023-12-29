using UnityEngine;

public class OutOfBoundDestroy : MonoBehaviour
{
    private const int bound = 30;

    private void FixedUpdate() => CheckOrDestroy();

    public virtual void CheckOrDestroy()
    {
        float currentZPos = Mathf.Abs(transform.position.z);
        if (currentZPos > bound)
            Destroy(gameObject);
    }
}