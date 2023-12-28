using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Action OnMove;

    private const int moveSpeed = 35;

    private void Start() => OnMove += Move;

    private void FixedUpdate()
    {
        if (GetHorizontalInput() != 0)
            OnMove.Invoke();
    }

    private void Move()
    {
        float p = Math.Abs(transform.position.x);
        float currentPos = transform.position.x;

        if (p < 20)
            transform.Translate(GetHorizontalInput() * moveSpeed * Time.fixedDeltaTime, 0, 0);
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
}
