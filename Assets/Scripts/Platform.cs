using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Components")]

    [SerializeField] private Rigidbody2D _rb2D;
    
    [Header("Settings")]

    [SerializeField] private float _dragSpeed;
  
    void Update()
    {
        DragSpeed();
    }

    private void DragSpeed()
    { 
        _rb2D.drag = _dragSpeed;
    }
}
