using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road : MonoBehaviour
{
    private List<Transform> m_RoadSections;
    private RoadColor m_RoadColor;

    private void Start()
    {
        m_RoadColor = new RoadColor();
        Setup();
    }

    public void Return(Transform roadSection)
    {
        m_RoadSections.Remove(roadSection);
        roadSection.position = GetReturnPosition(roadSection);
        m_RoadColor.SetColor(roadSection.GetComponent<MeshRenderer>());
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
            m_RoadColor.SetColor(roadSection.GetComponent<MeshRenderer>());
            m_RoadSections.Add(roadSection);
        }
    }
}

public class RoadColor
{
    private const float k_Hue = 0f;
    private const float k_Saturation = 0f;
    private const float k_MinValue = 0.25f;
    private const float k_MaxValue = 0.75f;

    private float m_Value = k_MinValue;
    private float m_ValueStep = 0.01f;

    public void SetColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.HSVToRGB(k_Hue, k_Saturation, m_Value);
        m_Value = Mathf.Clamp(m_Value + m_ValueStep, k_MinValue, k_MaxValue);
        m_ValueStep = m_Value <= k_MinValue || m_Value >= k_MaxValue ? -m_ValueStep : m_ValueStep;
    }
}
