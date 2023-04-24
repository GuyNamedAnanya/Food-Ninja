using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] float minMoveDistance = 0.3f;
    Rigidbody2D body;

    Vector3 lastMousePos;

    Collider2D myCollider;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myCollider.enabled = IsMouseMoving();
        BladeOnMouse();
    }

    void BladeOnMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        body.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(3);
        }
        if(collision.gameObject.CompareTag("Avocado"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(2);
        }
        if(collision.gameObject.CompareTag("Coconut"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(5);
        }
        if (collision.gameObject.CompareTag("Egg"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(1);
        }
        if (collision.gameObject.CompareTag("Lemon"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(1);
        }
        if (collision.gameObject.CompareTag("Pear"))
        {
            FindObjectOfType<GameManager>().IncreaseScore(4);
        }
    }
}
