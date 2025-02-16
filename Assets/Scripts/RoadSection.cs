using UnityEngine;

public class RoadSection : MonoBehaviour
{
    private RoadSectionMovement m_RoadSectionMovement;
    [SerializeField] private GameManager m_GameManager;
    private Road m_Road;

    public Road Road
    {
        get => m_Road;
        set => m_Road = value;
    }

    private void Start()
    {
        m_RoadSectionMovement = new RoadSectionMovement();
    }

    private void Update()
    {
        transform.position = m_RoadSectionMovement.UpdatePosition(transform.position, m_GameManager.Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Road.Return(transform);
    }
}

public class RoadSectionMovement
{
    public Vector3 UpdatePosition(Vector3 position, float speed)
    {
        var target = position + Vector3.back;
        var maxDistanceDelta = Time.deltaTime * speed;
        return Vector3.MoveTowards(position, target, maxDistanceDelta);
    }
}
