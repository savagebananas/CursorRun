using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    PlayerMovement player;
    TextMeshProUGUI distanceText;

    public GameObject panel;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        distanceText = GameObject.Find("Distance Text").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
    }

    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance.ToString();
    }
}
