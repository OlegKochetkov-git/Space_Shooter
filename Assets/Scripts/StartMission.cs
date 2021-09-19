using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMission : MonoBehaviour
{
    [SerializeField] List<GameObject> disabledObjects;

    public void SetAd()
    {
        foreach (GameObject item in disabledObjects)
        {
            item.SetActive(true);
        }
        

        gameObject.SetActive(false);
    }
}
