using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

}
