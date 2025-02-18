using UnityEngine;
using UnityEngine.InputSystem;

public enum Lane
{
    Left = -1,
    Middle = 0,
    Right = 1
}

public class Player : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;

    private void Start()
    {
        m_PlayerMovement = new PlayerMovement(transform.position);
    }

    private void Update()
    {
        transform.position = m_PlayerMovement.UpdatePosition(transform.position);
    }

    public void Player_Move(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            var horizontalInput = callbackContext.ReadValue<Vector2>().x;
            m_PlayerMovement.ChangeLanes(horizontalInput);
        }
    }
}

public class PlayerMovement
{
    private const float k_Speed = 15f;

    private Vector3 m_TargetPosition;
    private Lane m_CurrentLane = 0;

    public PlayerMovement(Vector3 position)
    {
        m_TargetPosition = position;
    }

    public void ChangeLanes(float horizontalInput)
    {
        var direction = horizontalInput == 0f ? 0f : Mathf.Sign(horizontalInput);
        m_CurrentLane = (Lane)Mathf.Clamp((float)m_CurrentLane + direction, (float)Lane.Left, (float)Lane.Right);
        m_TargetPosition = new Vector3((int)m_CurrentLane, m_TargetPosition.y, m_TargetPosition.z);
    }

    public Vector3 UpdatePosition(Vector3 position)
    {
        var maxDistanceDelta = Time.deltaTime * k_Speed;
        return Vector3.MoveTowards(position, m_TargetPosition, maxDistanceDelta);
    }
}
