using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;
[RequireComponent(typeof(Animator))] // 이 스크립트가 들어가는 오브젝트에는 무조건 이 컴포넌트가 들어있어야 한다. 만약 없다면 강제로라도 집어넣음
public class Player : MonoBehaviour
{
    public Transform bulletPrefab;
    Vector3 inputDir;
    PlayerInputActions inputActions;
    public float moveSpeed = 1.0f;
    Animator animator;
    public Transform fireTransform;
    readonly int InputY_String = Animator.StringToHash("InputY");
    public float hp = 3;
    public float collisionCooldown = 1.0f;
    public float fireCooldown = 0.3f;
    public Sprite[] fire;
    InputAction.CallbackContext fireContext;
    SpriteRenderer spriteRenderer;
    int score = 0;
    public Action<int> onScoreChange;

    public int Score
    {
        get => score;
        private set
        {
            if (score != value)
            {
                score = Math.Min(value, 99999);  // 최대 점수 99999
                onScoreChange?.Invoke(score);   // 이 델리게이트에 함수를 등록한 모든 대상에게 변경된 점수를 알림
            }
        }
    }

    /*    public Sprite[] idle;
        SpriteRenderer spriteRenderer;*/
    //이 스크립트가 포함된 게임오브젝트가 활성화되면 호출한다.
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        animator = GetComponent<Animator>();
        fireTransform = transform.GetChild(0);
        
    }
    //이 스크립트가 포함된 게임 오브젝트가 활성화되면 호출한다.
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Fire.canceled += OnFire;
        inputActions.Player.Boost.performed += OnBoost;
        inputActions.Player.Boost.canceled += OnBoost;
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

    }
    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Boost.canceled -= OnBoost;
        inputActions.Player.Boost.performed -= OnBoost;
        inputActions.Player.Fire.canceled -= OnFire;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Disable();
    }



    //이 스크립트가 포함된 게임오브젝트의 첫번째 update()함수가 실행되기 직전에 호출한다.
    private void Start()
    {  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        fireContext = context;
        if(fireContext.performed)
        {
            Debug.Log("onfire눌러짐");
            StartCoroutine(FireCooldown());

        }
        if(fireContext.canceled)
        {
            fireTransform.GetComponent<SpriteRenderer>().sprite = fire[1];
            Debug.Log("onfire떼어짐");
            StopAllCoroutines();
        }
    }
    private void OnFire()
    {
        fireTransform.GetComponent<SpriteRenderer>().sprite = fire[0];
        Instantiate(bulletPrefab, fireTransform.transform.position, Quaternion.identity);
        
    }
    private void OnBoost(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("onboost눌러짐");

        }
        if (context.canceled)
        {
            Debug.Log("onboost떼어짐");
        }
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        Debug.Log("좌표값: " + inputDir);
        /*if(inputDir.y > 0)
        {
            spriteRenderer.sprite = idle[2];
        }
        else if(inputDir.y < 0) 
        {
            spriteRenderer.sprite = idle[1];
        }
        else
        {
            spriteRenderer.sprite = idle[0];    
        }*/
        animator.SetFloat(InputY_String, inputDir.y);        
    }
    private void Move()
    {
        transform.Translate(moveSpeed * Time.fixedDeltaTime * inputDir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            OnDamage();
            Invoke("OffDamage", collisionCooldown);
        }
    }
    void OnDamage()
    {
        float count = 0;
        gameObject.layer = 9;
        Debug.Log(gameObject.layer);
        while(count <= 10)
        {
            if(count % 2 == 0)
            {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
            count++;
        }
        
        hp -= 1.0f;
        Debug.Log("현재 남은체력: " + hp);
        if (hp <= 0.0f)
        {
            Dead();
        }
    }
    void OffDamage()
    {
        Debug.Log("off데미지 호출");
        gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    IEnumerator FireCooldown()
    {
        while(true)
        {
            OnFire();
            yield return new WaitForSecondsRealtime(fireCooldown);
            fireTransform.GetComponent<SpriteRenderer>().sprite = fire[1];
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
    }
    public void AddScore(int getScore)
    {
        Score += getScore;
    }
}
