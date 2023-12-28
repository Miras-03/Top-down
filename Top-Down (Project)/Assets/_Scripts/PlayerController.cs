using System;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform bullet;
    private Action OnMove;

    private const int moveSpeed = 40;

    private void Start() => OnMove += Move;

    private void Update()
    {
        if (GetHorizontalInput() != 0)
            OnMove.Invoke();
        if (IsShooting())
            Instantiate(bullet, transform.localPosition, transform.localRotation);
    }

    private void Move()
    {
        float p = Math.Abs(transform.position.x);
        float currentPos = transform.position.x;

        if (p < 20)
            transform.Translate(GetHorizontalInput() * Time.deltaTime * moveSpeed, 0, 0);
        else
        {
            float currentZPos = transform.position.z;
            const float returnV = 0.1f;

            if (currentPos > 0)
                transform.position = new Vector3(currentPos - returnV, 0, currentZPos);
            else
                transform.position = new Vector3(currentPos + returnV, 0, currentZPos);
        }
    }

    private float GetHorizontalInput() => Input.GetAxis("Horizontal");

    private bool IsShooting() => Input.GetKeyDown(KeyCode.Space);
}