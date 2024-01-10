using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    public Action onDisable;

    protected virtual void OnEnable()
    {
        transform.localPosition = Vector3.zero;         //부모의 위치로 보내기
        transform.localRotation = Quaternion.identity;  //부모의 회전과 같게 만들기
    }
    private void OnDisable()
    {
        onDisable?.Invoke(); // 비활성화 되었음을 알림(풀만들때 할일이 등록되어야 함)
    }
    protected IEnumerator LifeOver(float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
