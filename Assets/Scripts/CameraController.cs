using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool movementEnabled = true;

    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            movementEnabled = !movementEnabled;
        }

        if (!movementEnabled)
        {
            return;
        }

        if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - panBoarderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed*Time.deltaTime, Space.World);
            //vector 3 forward is same as 0,0,1f, 0*1 = zero so only Z axis moves 
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            //vector 3 back is same as 0,0,-1f, 0*1 = zero so only Z axis moves 
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            //vector 3 right is same as 0,0,1f, 0*1 = zero so only Z axis moves 
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            //vector 3 forward is same as 0,0,1f, 0*1 = zero so only Z axis moves 
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll *1000* scrollSpeed* Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y,minY, maxY);

        transform.position = pos;
    }
}
