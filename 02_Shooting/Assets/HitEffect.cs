using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }
    public void EndAnim()
    {
        Destroy(this.gameObject);
    }
}
