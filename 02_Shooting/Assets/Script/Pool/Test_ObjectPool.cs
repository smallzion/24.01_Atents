using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_ObjectPool : TestBase
{
    public BulletPool bulletPool;
    public EnemyPool enemyPool;
    public ExplosionPool expPool;
    public ExplosionPool hitPool;

    private void Start()
    {
        bulletPool.Initialize();
    }

    protected override void OnTest1(InputAction.CallbackContext context)
    {
        Bullet bullet = bulletPool.GetObject();
    }
    protected override void OnTest2(InputAction.CallbackContext context)
    {
        //hit
        Explosion hit = hitPool.GetObject();
    }
    protected override void OnTest3(InputAction.CallbackContext context)
    {
        //enemy
        EnemyMovement enemy = enemyPool.GetObject();
    }
    protected override void OnTest4(InputAction.CallbackContext context)
    {
        //explosion
        Explosion explosion = expPool.GetObject();
    }
    protected override void OnTest5(InputAction.CallbackContext context)
    {
        base.OnTest5(context);
    }
}
