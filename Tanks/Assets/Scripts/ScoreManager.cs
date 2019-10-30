using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;   //variavel para armazenar o texto a receber o update de pontos

    private int points = 0;   //variavel contadora de pontos
    
    public int Points   //getset da variavel para somar pelo valor recebido em 'value' e chamar a função de update
    {
        get
        {
            return points;
        }

        set
        {
            points += value;

            UpdatePointsText();
        }
    }

    void Awake()
    {
        scoreText = GameObject.Find("Points").    //definir o componente da variavel de texto
    }

    void UpdatePointsText()
    {
        scoreText.text = Points.ToString();     //alterar o texto da variavel para a quantidade de pontos
    }
}