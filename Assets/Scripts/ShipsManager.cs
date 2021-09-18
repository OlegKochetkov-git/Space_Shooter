using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] List<PlayerShipConfig> ships;
    Vector2 pos;

    void Awake()
    {
        pos = transform.position;
        Instantiate(ships[0].GetShipPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    pos = FindObjectOfType<Player>().gameObject.transform.position;


        //    Destroy(FindObjectOfType<Player>().gameObject);
        //    Instantiate(ships[1].GetShipPrefab, pos, Quaternion.Euler(0f, 0f, -90f));

        //}
        //else if (Input.GetKeyDown(KeyCode.G))
        //{
        //    pos = FindObjectOfType<Player>().gameObject.transform.position;
        //    Destroy(FindObjectOfType<Player>().gameObject);
        //    Instantiate(ships[0].GetShipPrefab, pos, Quaternion.Euler(0f, 0f, -90f));
        //}
    }

    public void RespawnSecondShip()
    {
        pos = FindObjectOfType<Player>().gameObject.transform.position;
        Destroy(FindObjectOfType<Player>().gameObject);
        Instantiate(ships[1].GetShipPrefab, pos, Quaternion.Euler(0f, 0f, -90f));
    }
}
