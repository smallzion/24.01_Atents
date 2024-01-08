using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float MaxY = 4.0f, MinY = -4.0f;
    public float spawnDelay = 1.0f;
    //실습
    //1. 적을 스폰한다.
    //2. 랜덤한 높이로 생성된다.(y: +4 ~ -4)
    //3. 적은 위아래로 파도치듯이 움직인다
    //4. 계속 왼쪽 방향으로 움직인다.

    private void Start()
    {
        StartCoroutine(SpawnCorutine());
    }
    private void Update()
    {
        /*if(spawnTime > coolDown)
        {
            spawnTime = 0.0f;
            EnemySpawn();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }*/
        
    }
    private void EnemySpawn()
    {
        Instantiate(enemyPrefab, new Vector3(transform.position.x, Random.Range(MinY, MaxY), 0), Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 p0 = transform.position + Vector3.up * MaxY;
        Vector3 p1 = transform.position + Vector3.up * MinY;
        Gizmos.DrawLine(p0, p1);
    }
    private void OnDrawGizmosSelected()
    {
        //이 오브젝트를 선택했을때 사각형 그리기

        Gizmos.color = Color.red;
        Vector3 p0 = transform.position + Vector3.left * 0.5f + (Vector3.down * MaxY);
        Vector3 p1 = transform.position + Vector3.right * 0.5f + (Vector3.down * MaxY);
        Vector3 p2 = transform.position + Vector3.left * 0.5f + (Vector3.up * MaxY);
        Vector3 p3 = transform.position + Vector3.right * 0.5f + (Vector3.up * MaxY);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p0, p2);
        Gizmos.DrawLine(p1, p3);
    }
    IEnumerator SpawnCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            EnemySpawn();
        }
    }
}
