using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� ĳ������ Transform
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    public Vector3 offset; // ī�޶�� ĳ���� ������ �Ÿ�

    void LateUpdate()
    {
        // ī�޶��� ���ϴ� ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // ī�޶��� ���� ��ġ�� ���ϴ� ��ġ�� �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // ī�޶� �׻� ĳ���͸� �ٶ󺸵��� ��
        transform.LookAt(target);
    }
}

