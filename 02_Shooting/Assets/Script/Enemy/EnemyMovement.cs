using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : RecycleObject
{
    public float amlitude = 3.0f;
    public float frequeny = 2.0f;
    float spawnY = 0.0f;
    float elapsedTime = 0.0f;
    public float hp = 3.0f;
    public int enemyScore = 10;
    public Action onDie; // 임시
    Player player;

    //람다식, 람다함수(Lambda)
    //익명 함수

  /*  private void Start()
    {
        spawnY = transform.position.y;
        elapsedTime = 0.0f;

        Action aaa = () => Debug.Log("람다식");            //파라메터 없는 람다식
        Action<int> bbb = (x) => Debug.Log($"람다식{x}");  //파라메터가 하나인 람다식
        Func<int> ccc = () => 10;                          //파라메터 없고 항상 10을 리턴하는 람다식

        Player player = FindAnyObjectByType<Player>();
        onDie += () => player.AddScore(enemyScore);        //죽을때 플레이어의 AddScore함수에 파라미터로 enemyScore를 넣고 실행하도록 등록
    }*/
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        spawnY = transform.position.y;
        elapsedTime = 0.0f;

        /*Action aaa = () => Debug.Log("람다식");            //파라메터 없는 람다식
        Action<int> bbb = (x) => Debug.Log($"람다식{x}");  //파라메터가 하나인 람다식
        Func<int> ccc = () => 10;                          //파라메터 없고 항상 10을 리턴하는 람다식*/

        Player player = FindAnyObjectByType<Player>();
        onDie += () => player.AddScore(enemyScore);        //죽을때 플레이어의 AddScore함수에 파라미터로 enemyScore를 넣고 실행하도록 등록
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
            Debug.Log("체력" +  hp);
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
            Debug.Log(i + "번 반복");
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);

    }
}
