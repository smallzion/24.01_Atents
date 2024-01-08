using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI score;

    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Player player = FindAnyObjectByType<Player>();
        player.onScoreChange += RefreshScore;
    }

    private void RefreshScore(int newScore)
    {
        score.text = $"Score : {newScore:d5}";  // ������ ������ 5�ڸ��� ���. ���ڸ��� 0���� ä���
        //score.text = $"Score : {newScore,5}"; // ������ ������ 5�ڸ��� ���. ���ڸ��� �����̽��� ä���
    }
}
