using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public string axis = "Vertical";
    float v;
    Rigidbody2D rigid;
    [SerializeField] float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.sharedInstance.gameStarted == true)
        {
            v = Input.GetAxisRaw(axis);
            rigid.velocity = new Vector2(0, speed * v);
        }
    }
}
