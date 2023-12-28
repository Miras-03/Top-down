using UnityEngine;

public sealed class OutOfBoundDestroy : MonoBehaviour
{
    [SerializeField] private int boundDistance = 30;

    private void FixedUpdate()
    {
        float currentPos = Mathf.Abs(transform.position.z);
        if (currentPos > boundDistance)
            Destroy(gameObject);
    }
}