using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    static Parallax instance;
    [SerializeField] List<RawImage> planet1;
    [SerializeField] float speed1;
    //[SerializeField] RawImage planet2;
    [SerializeField] float speed2;

    //[SerializeField] RawImage planet3;
    [SerializeField] float speed3;


    void Awake()
    {
        //int number = FindObjectsOfType<Parallax>().Length;
        //if (number > 1)
        //{
        //    gameObject.SetActive(false);
        //    Destroy(gameObject);
        //}
        //else
        //{

        //DontDestroyOnLoad(gameObject);
        //}
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        MoveImage();
    }

    void MoveImage()
    {
        foreach (RawImage item in planet1)
        {
            
            Rect rect = item.uvRect;
            rect.x += speed1 * Time.deltaTime;
            item.uvRect = rect;
        }
        
    }
}
