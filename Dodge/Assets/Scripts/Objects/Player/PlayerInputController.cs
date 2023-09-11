using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Player _player;
    private InputAction _moveAction;
    private void Awake()
    {
        _player = this.GetComponent<Player>();
        _moveAction = this.gameObject.GetComponent<PlayerInput>().actions["Move"];
        _moveAction.canceled += ctx => OnMoveCanceled();
    }
    public void OnMove(InputValue value)
    {
        Debug.Log("ют╥б");
        Vector2 moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        if(moveInput.x > 0)
        {
            _player._animator.SetBool("Right", true);
        }
        else if(moveInput.x < 0)
        {
            _player._animator.SetBool("Left", true);
        }
        moveInput = Quaternion.Euler(0, 0, transform.eulerAngles.z) * moveInput;
        _player._rb2d.velocity = moveInput.normalized * _player.Speed;
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
        _player.Fire();
    }
    public void OnUseItem(InputValue value)
    {
        int _value = value.Get<int>();
        Managers.Data.UseItem(_value);
    }
}
