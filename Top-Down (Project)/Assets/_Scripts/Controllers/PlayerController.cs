using System;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform bullet;

    private const int moveSpeed = 40;

    private void Update()
    {
        if (IsShooting())
            Instantiate(bullet, transform.localPosition, transform.localRotation);
    }

    private void FixedUpdate()
    {
        if (GetHorizontalInput() != 0)
            HorizontalMove();
        if (GetVerticalInput() != 0)
            VerticalMove();
    }

    private void HorizontalMove()
    {
        float p = Math.Abs(transform.position.x);

        if (p < 20)
            transform.Translate(Vector3.right * GetHorizontalInput() * Time.deltaTime * moveSpeed);
        else
        {
            const float returnV = 0.1f;
            float newXPos = transform.position.x;
            Vector3 currentPos = transform.position;

            newXPos = newXPos < 0 ? newXPos + returnV : newXPos - returnV;

            transform.position = new Vector3(newXPos, currentPos.y, currentPos.z);
        }
    }

    private void VerticalMove()
    {
        float p = Math.Abs(transform.position.z);

        if (p < 16 && p > 8)
            transform.Translate(Vector3.forward * GetVerticalInput() * Time.deltaTime * moveSpeed);
        else
        {
            const float returnV = 0.1f;
            float newXPos = transform.position.z;
            Vector3 currentPos = transform.position;

            newXPos = newXPos < 13 ? newXPos + returnV : newXPos - returnV;

            transform.position = new Vector3(currentPos.x, currentPos.y, newXPos);
        }
    }

    private float GetHorizontalInput() => Input.GetAxis("Horizontal");

    private float GetVerticalInput() => Input.GetAxis("Vertical");

    private bool IsShooting() => Input.GetKeyDown(KeyCode.Space);
}