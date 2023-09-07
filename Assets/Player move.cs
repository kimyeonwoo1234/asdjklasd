using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool flipSprite = true; // 좌우 반전 여부를 결정하는 플래그

    void Update()
    {
        // 키보드 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        // 이동 벡터 계산
        Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;

        // 캐릭터 이동
        transform.Translate(moveVector);

        // 캐릭터 방향 조절 (마우스 방향을 바라봄 - 좌우로만 회전)
        if (flipSprite)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDirection = mousePosition - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // 좌우 회전만 가능하도록 제한
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

