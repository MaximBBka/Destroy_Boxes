using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; // ������ �� ��������� SpriteRenderer �������
    [SerializeField] private Camera camera;
    public float a = 0f;
    void OnValidate()
    {
        // ���������, ���� �� ��������� SpriteRenderer
        if (spriteRenderer != null)
        {
            // �������� ������� �������
            float spriteHeight = spriteRenderer.bounds.size.y;

            // �������� ������ ��������������� ������
            camera.orthographicSize = spriteHeight / 2f; // ������������� �������� ������ ������� ��� ������ ������
        }
    }
}
