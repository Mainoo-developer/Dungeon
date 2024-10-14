using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    // 부모 클래스에서 Awake가 virtual로 정의되어 있으니 그거에 얹어서! 추가적인 로직을 실행해야겠죠?
    protected override void Awake()
    {
        // 부모의 Awake도 빼먹지 말고 실행하라는 의미
        base.Awake();
        camera = Camera.main;
    }


    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);

        //실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovement라는 곳에서 합니다

    }
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }
    public void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }
}
