using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject[] weapons;

    private GameObject rotationLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationLayer = transform.Find("RotationLayer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hInput,0, vInput);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
}
