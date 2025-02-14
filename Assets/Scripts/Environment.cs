using UnityEngine;

public class Environment : MonoBehaviour
{
    private float _speed = 10;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed);
    }
}
