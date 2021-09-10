using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomPosInArea : MonoBehaviour
{
    [SerializeField] Transform positionMaxX;
    [SerializeField] Transform positionMinX;
    [SerializeField] Transform positionMaxY;
    [SerializeField] Transform positionMinY;

    float maxX;
    float minX;
    float maxY;
    float minY;

    public Vector2 GetRandomPosInArea()
    {
        maxX = positionMaxX.position.x;
        minX = positionMinX.position.x;

        maxY = positionMaxY.position.y;
        minY = positionMinY.position.y;

        var randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        return randomPos;
    }

}
