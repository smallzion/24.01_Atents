using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Instantiate : TestBase
{
    public GameObject prefab;
    private void Update()
    {
        
    }
    IEnumerator TestCorutine()
    {
        Debug.Log("코루틴 시작");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("'코루틴 종료");
    }
    protected override void OnTest1(InputAction.CallbackContext context)
    {
        new GameObject();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        Instantiate(prefab);
        //로컬좌표: 부모기준으로 한 좌표(부모가 없으면 월드가 부모)
        //월드좌표: 맵(월드)의 원점(origin)을 기준으로 한 좌표
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        Instantiate(prefab, new Vector3(5, 0, 0), Quaternion.identity);
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        Instantiate(prefab, transform);
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        StartCoroutine(TestCorutine());
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
