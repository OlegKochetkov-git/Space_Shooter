using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        healthText = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        healthText.text = player.GetHealth().ToString();
    }
}
