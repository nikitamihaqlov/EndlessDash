using UnityEngine;

public class Movement
{
    public Vector3 UpdatePosition(Vector3 position, float speed)
    {
        var target = position + Vector3.back;
        var maxDistanceDelta = Time.deltaTime * speed;
        return Vector3.MoveTowards(position, target, maxDistanceDelta);
    }
}
