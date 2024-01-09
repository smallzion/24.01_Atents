using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float amlitude = 3.0f;
    public float frequeny = 2.0f;
    float spawnY = 0.0f;
    float elapsedTime = 0.0f;
    public float hp = 3.0f;
    public int enemyScore = 10;
    public Action onDie; // �ӽ�

    //���ٽ�, �����Լ�(Lambda)
    //�͸� �Լ�

    private void Start()
    {
        spawnY = transform.position.y;
        elapsedTime = 0.0f;

        Action aaa = () => Debug.Log("���ٽ�");            //�Ķ���� ���� ���ٽ�
        Action<int> bbb = (x) => Debug.Log($"���ٽ�{x}");  //�Ķ���Ͱ� �ϳ��� ���ٽ�
        Func<int> ccc = () => 10;                          //�Ķ���� ���� �׻� 10�� �����ϴ� ���ٽ�

        Player player = FindAnyObjectByType<Player>();
        onDie += () => player.AddScore(enemyScore);        //������ �÷��̾��� AddScore�Լ��� �Ķ���ͷ� enemyScore�� �ְ� �����ϵ��� ���
    }
    void Update()
    {
        elapsedTime += Time.deltaTime * frequeny;
        transform.position = new Vector3(transform.position.x - Time.deltaTime, spawnY + Mathf.Sin(elapsedTime) * amlitude, 0.0f);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            OnDamage();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }


    }
    private void OnDamage()
    {
        if (hp > 0.0f)
        {
            hp--;
            Debug.Log("ü��" +  hp);
        }
        else
        {  
            OnDie();

        }
    }
    void OnDie()
    {
 //       Player player = FindAnyObjectByType<Player>();
        onDie?.Invoke();
        //StartCoroutine(AddScoreWithDelay(player, enemyScore));
        Destroy(gameObject);
    }

    IEnumerator AddScoreWithDelay(Player player, int score)
    {

        for (int i = 0; i < score; i++)
        {
            player.AddScore(1);
            Debug.Log(i + "�� �ݺ�");
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);

    }
}
