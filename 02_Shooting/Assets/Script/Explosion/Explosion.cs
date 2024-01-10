using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : RecycleObject
{
    // Start is called before the first frame update
    private Animator m_Animator;
    float animLength = 0f;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        //애니메이터 클립길이 받아오기
        //GetCurrentAnimatorClipInfo(0): 애니메이터의 첫번째 레이어의 정보를 가져오기
        //GetCurrentAnimatorClipInfo(0)[0]: 애니메이터의 첫번째 레이어에 있는 애니메이션 클립중 첫번째 클립의 정보 받아오기
        animLength = m_Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(LifeOver());
    }
}
