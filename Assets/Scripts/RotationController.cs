using UnityEngine;
using System.Collections;

public class RotationController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * speed);
    }
}
