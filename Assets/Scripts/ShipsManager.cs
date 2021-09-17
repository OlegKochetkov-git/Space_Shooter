using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : MonoBehaviour
{
    [SerializeField] List<PlayerShipConfig> ships;
    bool isShip1;

    void Awake()
    {
        Instantiate(ships[0].GetShipPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(FindObjectOfType<Player>().gameObject);
            Instantiate(ships[1].GetShipPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));

        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Destroy(FindObjectOfType<Player>().gameObject);
            Instantiate(ships[0].GetShipPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        }
    }
}
