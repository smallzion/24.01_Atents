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
        /*spriteRenderer = GetComponent<SpriteRenderer>();*/
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("onfire눌러짐");
            Instantiate(bulletPrefab, fireTransform.transform.position, Quaternion.identity);
        }
        if(context.canceled)
        {
            Debug.Log("onfire떼어짐");
        }
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
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
