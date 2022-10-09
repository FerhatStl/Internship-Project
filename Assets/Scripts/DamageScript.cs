using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        parentTransform.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
