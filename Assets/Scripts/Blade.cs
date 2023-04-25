using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] float minMoveDistance = 0.3f;

    Rigidbody2D body;
    Vector3 lastMousePos;
    Collider2D myCollider;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }
    
    void Update()
    {
        myCollider.enabled = IsMouseMoving();
        BladeOnMouse();
    }

    /// <summary>
    /// Sets the blade gameobject to mouse
    /// </summary>
    void BladeOnMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        body.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    /// <summary>
    /// Checks if the mouse is moving or stationery 
    /// and based on that turns the collider on and off
    /// </summary>
    /// <returns></returns>
    bool IsMouseMoving()
    {
        Vector3 currentMousePos = transform.position;
        float distanceTravelledByMouse = (lastMousePos - currentMousePos).magnitude;
        lastMousePos = currentMousePos;

        if(distanceTravelledByMouse > minMoveDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Sets the score of each fruit
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(3);
        }
        if(collision.gameObject.CompareTag("Avocado"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(3);
        }
        if(collision.gameObject.CompareTag("Coconut"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(2);
        }
        if (collision.gameObject.CompareTag("Egg"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(5);
        }
        if (collision.gameObject.CompareTag("Lemon"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(5);
        }
        if (collision.gameObject.CompareTag("Pear"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(4);
        }
    }
}
