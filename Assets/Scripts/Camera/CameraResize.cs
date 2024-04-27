using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer спрайта
    [SerializeField] private Camera camera;
    public float a = 0f;
    void OnValidate()
    {
        // Проверяем, есть ли компонент SpriteRenderer
        if (spriteRenderer != null)
        {
            // Получаем размеры спрайта
            float spriteHeight = spriteRenderer.bounds.size.y;

            // Настроим размер ортографической камеры
            camera.orthographicSize = spriteHeight / 2f; // Устанавливаем половину высоты спрайта как размер камеры
        }
    }
}
