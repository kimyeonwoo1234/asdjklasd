using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool flipSprite = true; // �¿� ���� ���θ� �����ϴ� �÷���

    void Update()
    {
        // Ű���� �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �̵� ���� ���
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // �̵� ���� ���
        Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;

        // ĳ���� �̵�
        transform.Translate(moveVector);

        // ĳ���� ���� ���� (���콺 ������ �ٶ� - �¿�θ� ȸ��)
        if (flipSprite)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDirection = mousePosition - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // �¿� ȸ���� �����ϵ��� ����
            if (angle > 90 || angle < -90)
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

