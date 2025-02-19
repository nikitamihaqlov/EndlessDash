using UnityEngine;

[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    private float m_Speed = 3f;

    public float Speed => m_Speed;
}
