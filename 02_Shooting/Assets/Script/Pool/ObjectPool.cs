using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
{
    /// <summary>
    /// Ǯ���� ������ ������Ʈ�� ������
    /// </summary>
    public GameObject originalPrefab;

    /// <summary>
    /// Ǯ�� ũ��, ó���� �����ϴ� ������Ʈ�� ����, ��� ������ 2^n�� ��� ���� ����.
    /// </summary>
    public int poolSize = 64;

    /// <summary>
    /// TŸ������ ������ ������Ʈ�� �迭, ������ ��� ������Ʈ�� �ִ� �迭
    /// </summary>
    T[] pool;

    /// <summary>
    /// ���� ��밡����(��Ȱ��ȭ �Ǿ��ִ�) ������Ʈ���� �����ϴ� ť
    /// </summary>
    Queue<T> readyQueue;

    public void Initialize()
    {
        pool = new T[poolSize];
        readyQueue = new Queue<T>(poolSize);

        GenarateObjects(0, poolSize, pool);
    }/// <summary>
    /// Ǯ���� ����� ������Ʈ�� �����ϴ� �Լ�
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="results"></param>
    void GenarateObjects(int start, int end, T[] results)
    {
        for(int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(originalPrefab, transform);
            obj.name = $"{originalPrefab.name}_{i}";

            T comp = obj.GetComponent<T>();
            obj.SetActive(false);
        }

    }
}
