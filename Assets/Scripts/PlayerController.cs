using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject[] weapons = null;

    private Camera mainCamera;
    private Transform aimer;
    private GameObject currentWeapon;
    private iWeapon currWeaponInterface;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

        // Select weapon to use
        // TODO: Create method for selecting the starting weapon
        currentWeapon = weapons[0];
        currWeaponInterface = currentWeapon.GetComponent<iWeapon>();

        // Instantiate weapon and move to correct location
        // TODO: Move to separate method
        aimer = GameObject.Find("Aimer").transform;
        Vector3 weaponPos = new Vector3(aimer.position.x, aimer.position.y, aimer.position.z + 2.0f);
        GameObject weapon = Instantiate(currentWeapon, weaponPos, currentWeapon.transform.rotation);
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

        // Shoot weapon with mouse
        if (Input.GetMouseButtonDown(0))
        {
            currWeaponInterface.fire();
        }
    }
}
