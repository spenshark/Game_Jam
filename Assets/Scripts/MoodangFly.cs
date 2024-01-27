using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoodangFly : MonoBehaviour
{
    public float flySpeed = 0.02f; 
    void Update()
    {
        Vector2 moveDirection = new Vector2(flySpeed * (-1), 0f);  
        transform.Translate(moveDirection * Time.deltaTime);
    }
}
