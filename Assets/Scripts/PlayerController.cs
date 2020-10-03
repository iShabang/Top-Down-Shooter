using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private GameObject[] weapons = null;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera mainCamera;

    private GameObject currentWeapon;
    private iWeapon currWeaponInterface;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Select weapon to use
        // TODO: Create method for selecting the starting weapon
        GameObject weaponPrefab = weapons[0];

        // Instantiate weapon and move to correct location
        // TODO: Move to separate method
        Vector3 weaponPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.0f);
        currentWeapon = Instantiate(weaponPrefab, weaponPos, weaponPrefab.transform.rotation);
        currentWeapon.transform.position = weaponPos;
        currentWeapon.transform.SetParent(transform,true);
        currWeaponInterface = currentWeapon.GetComponent<iWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        // Mouse Aim
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        // Shoot weapon with mouse
        if (Input.GetMouseButtonDown(0))
        {
            currWeaponInterface.fire();
        }
    }
}
