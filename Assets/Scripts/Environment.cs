using UnityEngine;

public class Environment : MonoBehaviour
{
    private float _speed = 10;

    [SerializeField] private Transform _returnTransform;

    private const float _zBound = -10;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed);

        if (transform.position.z < _zBound)
        {
            transform.position = _returnTransform.position;
        }
    }
}
