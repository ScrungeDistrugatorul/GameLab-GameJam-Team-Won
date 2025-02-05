using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float offset;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);
    }
}
