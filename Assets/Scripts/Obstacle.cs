using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Movement m_Movement;
    [SerializeField] private GameManager m_GameManager;

    private void Start()
    {
        m_Movement = new Movement();
    }

    private void Update()
    {
        transform.position = m_Movement.UpdatePosition(transform.position, m_GameManager.Speed);
    }
}
