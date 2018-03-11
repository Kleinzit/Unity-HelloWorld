using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsMouse();
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 rightMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * right;
        Vector3 forwardMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime * forward;

        transform.position += rightMove;
        transform.position += forwardMove;
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Vector3.Normalize(Quaternion.Euler(0, 45, 0) * new Vector3(mousePos.x - objectPos.x, 0, mousePos.y - objectPos.y));
        transform.forward = dir;
    }
}
