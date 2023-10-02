using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Gold: " + bank.CurrentBalance.ToString();
    }
}
