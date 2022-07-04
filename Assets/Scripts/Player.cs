using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    internal static Player instance = null;

    [SerializeField] internal SkinnedMeshRenderer playerMeshRenderer = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if( instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }
    
    

}
