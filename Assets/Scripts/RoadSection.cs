using UnityEngine;

public class RoadSection : MonoBehaviour
{
    private Movement m_Movement;
    [SerializeField] private GameManager m_GameManager;
    private Road m_Road;

    public Road Road
    {
        get => m_Road;
        set => m_Road = value;
    }

    private void Start()
    {
        m_Movement = new Movement();
    }

    private void Update()
    {
        transform.position = m_Movement.UpdatePosition(transform.position, m_GameManager.Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Road.Return(transform);
    }
}
