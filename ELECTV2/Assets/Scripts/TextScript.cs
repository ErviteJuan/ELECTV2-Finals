using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public float DestroyTime = 0.5f;
    public Vector3 Offset = new Vector3 (0, 0, 0);
    public void Start()
    {
        Destroy(this.gameObject, DestroyTime);

        transform.localPosition += Offset;
    }
}
