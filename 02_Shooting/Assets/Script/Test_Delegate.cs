using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Delegate : TestBase
{
    //delegate(��������Ʈ)
    //- �Լ��� ������ �� �ִ� ���� Ÿ��
    //- �Լ� ü��(chain)�� ����
    //- � ����� �߻������� �˸��� ����ϸ� ��

    public delegate void TestDelegate(); //��������Ʈ Ÿ���� �ϳ� ���� (�� ��������Ʈ�� �Ķ���Ͱ� ���� ���ϰ��� ���� �Լ��� ������ �� �ִ�.)
    TestDelegate aaa; //TestDelegateŸ������ �Լ��� ������ �� �ִ� aaa��� ������ ����

    void TestRun()
    {
        Debug.Log("TestRun");
    }
    private void Start()
    {
        aaa = TestRun; //������ �ִ� �Լ����� �� �����ϰ� TestRun�� �߰�
        aaa += TestRun; //������ �ִ� �Լ��� �ڿ� TestRun �߰�
        aaa = TestRun + aaa; // aaa �� �տ� TestRun�߰�
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        aaa();
    }
}
