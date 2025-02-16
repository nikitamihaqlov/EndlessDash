using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road : MonoBehaviour
{
    private List<Transform> m_RoadSections;

    private void Start()
    {
        Setup();
    }

    public void Return(Transform roadSection)
    {
        m_RoadSections.Remove(roadSection);
        roadSection.position = GetReturnPosition(roadSection);
        m_RoadSections.Add(roadSection);
    }

    private Vector3 GetReturnPosition(Transform roadSection)
    {
        var lastRoadSection = m_RoadSections.Last();
        var offset = Vector3.forward * (lastRoadSection.localScale.z + roadSection.localScale.z) / 2;
        return lastRoadSection.position + offset;
    }

    private void Setup()
    {
        m_RoadSections = new List<Transform>();
        foreach (Transform roadSection in transform)
        {
            roadSection.GetComponent<RoadSection>().Road = this;
            m_RoadSections.Add(roadSection);
        }
    }
}
