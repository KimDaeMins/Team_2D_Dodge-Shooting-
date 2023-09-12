using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Player _player;
    private InputAction _moveAction;
    Vector2 _moveInput;
    Quaternion _look;
    private void Awake()
    {
        _moveAction = this.gameObject.GetComponent<PlayerInput>().actions["Move"];
        _moveAction.canceled += ctx => OnMoveCanceled();
        _player = this.GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        _look = Quaternion.Euler(0, 0, transform.eulerAngles.z);
        Vector2 rawmoveInput = _look * _moveInput;
        _player._rb2d.velocity = rawmoveInput.normalized * _player.Speed;
    }
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
        if (_moveInput.x > 0)
        {
            _player._animator.SetBool("Right", true);
        }
        else if(_moveInput.x < 0)
        {
            _player._animator.SetBool("Left", true);
        }
       
    }
    public void OnMoveCanceled()
    {
        _player._animator.SetBool("Left", false);
        _player._animator.SetBool("Right", false);
    }
    public void OnLook(InputValue value)
    {
        Vector2 _newAim = value.Get<Vector2>();
        Vector2 worldPos = _player._camera.ScreenToWorldPoint(_newAim);
        _newAim = (worldPos - (Vector2)transform.position).normalized;
        float rotz = Mathf.Atan2(_newAim.y, _newAim.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotz - 90f);
        
    }
    public void OnFire(InputValue value)
    {
        Vector2 mousePostion = _player._camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _player._aim = (mousePostion - (Vector2)(this.transform.position)).normalized;
        _player.Fire();
    }
    public void OnUseItem(InputValue value)
    {
        if (value.isPressed == false)
        {
        return;
        }
        object obj = value.Get();
        int index = Convert.ToInt32(obj);
        Managers.Data.UseItem(index-1); // 입력 키의 인덱스에서 1을 빼서 인덱스로 사용합니다.
    }
}
