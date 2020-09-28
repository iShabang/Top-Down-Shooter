using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject[] weapons = null;

    private Camera mainCamera;
    private Transform aimer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        aimer = GameObject.Find("Aimer").transform;
        Vector3 weaponPos = new Vector3(aimer.position.x, aimer.position.y, aimer.position.z + 2.0f);
        GameObject weapon = Instantiate(weapons[0], weaponPos, weapons[0].transform.rotation);
        weapon.transform.SetParent(aimer,true);

    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hInput,0, vInput);
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        // Mouse Aim
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            aimer.transform.LookAt(new Vector3(pointToLook.x,aimer.transform.position.y,pointToLook.z));
        }
    }
}
