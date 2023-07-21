using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's Transform reference

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }
}