using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DetectarTrigger3D : MonoBehaviour
{
    public string tag1;

    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tag1)
        {
            OnEnter.Invoke();
        }
    }
}