using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // Drag the object you want to follow here

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}