using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator m_Animator;
    float animLength = 0f;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        //�ִϸ����� Ŭ������ �޾ƿ���
        //GetCurrentAnimatorClipInfo(0): �ִϸ������� ù��° ���̾��� ������ ��������
        //GetCurrentAnimatorClipInfo(0)[0]: �ִϸ������� ù��° ���̾ �ִ� �ִϸ��̼� Ŭ���� ù��° Ŭ���� ���� �޾ƿ���
        animLength = m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }
    public void EndAnim()
    {
        Destroy(this.gameObject);
    }
}
