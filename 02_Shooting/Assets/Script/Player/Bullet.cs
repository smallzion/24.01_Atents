using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public GameObject EffectPrefab;

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * new Vector3(bulletSpeed, Random.Range(-10.0f, 10.0f), 0);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    //1. bullet 프리팹에 필요한 ㄴ컴포넌트 추가 및 설정
    //2. 총알은 ememy태그를 가진 오브젝트와 부딪히면 대상 삭제.
    // 3. 총알은 다른 오브젝트와 부딪히면 자기 자신 삭제
    // 4. hit 스프라이트를 이용해 hiteffect프리팹 생성
    //5. 총알이 부딪힌 위치에 hiteffect 생성
    //6. hiteffect는 한번만 재생
}