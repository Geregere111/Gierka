using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    Vector3 tempMove = Vector3.zero;
    [SerializeField][Range(0.001f, 100f)]
    float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        tempMove.x = x;
        tempMove.y = y;
        tempMove.Normalize();
        tempMove *= Time.deltaTime * movementSpeed;
        transform.position += tempMove;
    }
}
