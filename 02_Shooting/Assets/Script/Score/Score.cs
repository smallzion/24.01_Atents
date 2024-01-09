using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI score;
    int goalScore = 0;
    float currentScore = 0.0f;
    public float scoreUpSpeed = 50.0f;

    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Player player =  FindAnyObjectByType<Player>();
        player.onScoreChange += RefreshScore;
        score.text = "Score: 00000";
    }
    private void Update()
    {
        if(currentScore < goalScore)//������ �ö󰡴� ����
        {
            float speed = Mathf.Max((goalScore - currentScore) * 5.0f, scoreUpSpeed); // �ּ� scoreUpSpeed ����

            currentScore += Time.deltaTime * speed;
            currentScore = Mathf.Min(currentScore, goalScore);
            int temp = (int)currentScore;
            score.text = $"Score: {temp:d5}";
            //score.text = $"Score : {currentScore:f0}; // �Ҽ��� ��� ���ϱ�
        }
    }

    private void RefreshScore(int newScore)
    {
        //score.text = $"Score : {newScore:d5}";  // ������ ������ 5�ڸ��� ���. ���ڸ��� 0���� ä���
        //score.text = $"Score : {newScore,5}"; // ������ ������ 5�ڸ��� ���. ���ڸ��� �����̽��� ä���
        goalScore = newScore;
    }
}
