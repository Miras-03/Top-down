using UnityEngine;

public sealed class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) => Destroy(collision.gameObject);
}