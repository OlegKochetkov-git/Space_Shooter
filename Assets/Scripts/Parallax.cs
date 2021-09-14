using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] RawImage img;
    [SerializeField] float speed;

    void Update()
    {
        MoveImage();
    }

    void MoveImage()
    {
        Rect rect = img.uvRect;
        rect.x += speed * Time.deltaTime;
        img.uvRect = rect;
    }
}
