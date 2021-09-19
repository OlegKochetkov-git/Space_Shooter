using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationOfTypingText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI animaitedText;
    string text;

    
    void Start()
    {
        text = animaitedText.text;
        animaitedText.text = "";
        StartCoroutine(TextCoruitine());
    }

    IEnumerator TextCoruitine()
    {
        foreach (char item in text)
        {
            animaitedText.text += item;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
