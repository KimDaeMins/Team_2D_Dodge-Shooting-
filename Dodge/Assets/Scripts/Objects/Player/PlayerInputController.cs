using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Player
{
    private Camera _camera;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] Animator _animator;
    [SerializeField] InputAction _moveAction;
    private void Awake()
    {
        _moveAction = this.gameObject.GetComponent<PlayerInput>().actions["Move"];
        _camera = Camera.main;
        _moveAction.canceled += ctx => OnMoveCanceled();
    }
    public void OnMove(InputValue value)
    {
        Debug.Log("입력");
        Vector2 moveInput = value.Get<Vector2>().normalized;
        if(moveInput.x > 0)
        {
            _animator.SetBool("Right", true);
        }
        else if(moveInput.x < 0)
        {
            _animator.SetBool("Left", true);
        }
        _rb2d.velocity = moveInput * _speed;
    }
    public void OnMoveCanceled()
    {
        _animator.SetBool("Left", false);
        _animator.SetBool("Right", false);
    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        float rotz = Mathf.Atan2(newAim.y, newAim.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotz - 88f);
    }
    public void OnFire(InputValue value)
    {
        Debug.Log("발사");
    }
}
