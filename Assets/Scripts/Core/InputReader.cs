using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string JumpButtonName = "Jump";

    private bool _isJump;
    private bool _isAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetButtonDown(JumpButtonName))
            _isJump = true;

        if (Input.GetMouseButtonDown(0))
            _isAttack = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;

        value = false;

        return localValue;
    }
}
