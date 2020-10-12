using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       cam.transform.position = new Vector3 (player.position.x, transform.position.y, player.position.z); 
    }
}
