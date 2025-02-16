using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float m_Speed = 3f;

    public float Speed => m_Speed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
