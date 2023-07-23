using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI titleUI;
    public string title;

    void Start()
    {
        StartCoroutine(TypeSentence(title));
    }

    void Update()
    {

    }

    IEnumerator TypeSentence(string sentence)
    {
        titleUI.text = "";
        foreach(char letter in title.ToCharArray())
        {
            titleUI.text += letter;
            yield return new WaitForSeconds(0.2f);
        }
        button.SetActive(true);
    }
}
