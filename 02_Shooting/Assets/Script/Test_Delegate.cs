using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Delegate : TestBase
{
    //delegate(델리게이트)
    //- 함수를 저장할 수 있는 변수 타입
    //- 함수 체인(chain)이 가능
    //- 어떤 사건이 발생했음을 알릴때 사용하면 편리

    public delegate void TestDelegate(); //델리게이트 타입을 하나 생성 (이 델리게이트는 파라메터가 없고 리턴값도 없는 함수만 저장할 수 있다.)
    TestDelegate aaa; //TestDelegate타입으로 함수를 저장할 수 있는 aaa라는 변수를 만듬

    void TestRun()
    {
        Debug.Log("TestRun");
    }
    private void Start()
    {
        aaa = TestRun; //이전에 있던 함수들을 다 무시하고 TestRun만 추가
        aaa += TestRun; //이전에 있던 함수들 뒤에 TestRun 추가
        aaa = TestRun + aaa; // aaa 맨 앞에 TestRun추가
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        aaa();
    }
}
