using System.Threading;
using UnityEngine;

public sealed class MoveForward : MonoBehaviour
{
    [SerializeField] private int speed = 10;

    private void FixedUpdate() => transform.Translate(Vector3.forward * Time.fixedDeltaTime *  speed);
}