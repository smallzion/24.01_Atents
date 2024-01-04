using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    TestInputAction inputActions;

    private void Awake()
    {
        inputActions = new TestInputAction();
    }
    private void OnEnable()
    {
        inputActions.Test.Enable();
        inputActions.Test.Test1.performed += OnTest1;
        inputActions.Test.Test2.performed += OnTest2;
        inputActions.Test.Test3.performed += OnTest3;
        inputActions.Test.Test4.performed += OnTest4;
        inputActions.Test.Test5.performed += OnTest5;
        inputActions.Test.LClick.performed += OnLClick;
        inputActions.Test.RClick.performed += OnRClick;
    }
    private void OnDisable()
    {
        inputActions.Test.RClick.performed -= OnRClick;
        inputActions.Test.LClick.performed -= OnLClick;
        inputActions.Test.Test5.performed -= OnTest5;
        inputActions.Test.Test4.performed -= OnTest4;
        inputActions.Test.Test3.performed -= OnTest3;
        inputActions.Test.Test2.performed -= OnTest2;
        inputActions.Test.Test1.performed -= OnTest1;
        inputActions.Test.Disable();
    }
    
    protected virtual void OnRClick(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnLClick(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest5(InputAction.CallbackContext context)
    {
    }
    protected virtual void OnTest4(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest3(InputAction.CallbackContext context)
    {
    }

    protected virtual void OnTest2(InputAction.CallbackContext context)
    {
    }
    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
    }
    
}
