using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float amlitude = 3.0f;
    public float frequeny = 2.0f;
    float spawnY = 0.0f;
    float elapsedTime = 0.0f;
    private void Start()
    {
        spawnY = transform.position.y;
        elapsedTime = 0.0f;
    }
    void Update()
    {
        elapsedTime += Time.deltaTime * frequeny;
        transform.position = new Vector3(transform.position.x - Time.deltaTime, spawnY + Mathf.Sin(elapsedTime) * amlitude, 0.0f);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
