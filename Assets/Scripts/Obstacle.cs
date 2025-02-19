using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
