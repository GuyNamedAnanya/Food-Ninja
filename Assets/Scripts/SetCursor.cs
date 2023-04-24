using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    [SerializeField] Texture2D knifeCursor;
    void Start()
    {
        Cursor.SetCursor(knifeCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
