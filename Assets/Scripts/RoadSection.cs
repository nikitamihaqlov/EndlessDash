using UnityEngine;

public class RoadSection : MonoBehaviour
{
    private Road m_Road;

    public Road Road
    {
        get => m_Road;
        set => m_Road = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        Road.Return(transform);
    }
}
