using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Parallax : MonoBehaviour
{
    static Parallax instance;

    [SerializeField] List<RawImage> planets;
    [SerializeField] List<float> speed;

    void Awake()
    {
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
        MoveImage(planets, speed);
    }

    void MoveImage(List<RawImage> planets, List<float> speed)
    {
        for (int numberOfPlanet = 0; numberOfPlanet < planets.Count; numberOfPlanet++)
        {
            Rect rect = planets[numberOfPlanet].uvRect;
            rect.x += speed[numberOfPlanet] * Time.deltaTime;
            planets[numberOfPlanet].uvRect = rect;
        }
    }
}
