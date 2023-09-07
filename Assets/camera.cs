using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 캐릭터의 Transform
    public float smoothSpeed = 0.125f; // 카메라 이동 속도
    public Vector3 offset; // 카메라와 캐릭터 사이의 거리

    void LateUpdate()
    {
        // 카메라의 원하는 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 카메라의 현재 위치를 원하는 위치로 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 카메라가 항상 캐릭터를 바라보도록 함
        transform.LookAt(target);
    }
}

