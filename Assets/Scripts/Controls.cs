using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public Camera exteriorCamera;
    public string ViewType = "Exterior";
    public GameObject planeExterior;

    public int spinSpeed = 20;
    public int zoomSpeed = 10;

    private int zoom = 0;
    private int rotateZ = 0, rotateY = 0, rotateX = 0;
    void Start()
    {
        if (exteriorCamera == null)
        {
            exteriorCamera = GameObject.Find("ExteriorCamera").GetComponent<Camera>();
        }
        if (planeExterior == null)
        {
            planeExterior = GameObject.Find("PlaneExterior");
        }
    }

    void Update()
    {
        //Process Zoom
        if(ViewType.Equals("Exterior"))
        {
            if (exteriorCamera.fieldOfView + (zoom * Time.deltaTime) > 2 && exteriorCamera.fieldOfView + (zoom * Time.deltaTime) < 60)
            {
                exteriorCamera.fieldOfView = exteriorCamera.fieldOfView + (zoom * Time.deltaTime);
            }
            else
                StopZoom();

            planeExterior.transform.Rotate(new Vector3(rotateX * Time.deltaTime, rotateY * Time.deltaTime, rotateZ * Time.deltaTime),Space.Self);
        }
    }

    public void StartZoom(int direction)
    {
        //Negative values move in, positive values move out
        zoom = direction * zoomSpeed; 
    }

    public void StopZoom()
    {
        zoom = 0;
    }

    public void StartRotation(string direction)
    {
        //Y rotates left to right, Z rotates up and down
        if (direction.Equals("Left"))
            rotateY = spinSpeed;
        if (direction.Equals("Right"))
            rotateY = -spinSpeed;
        if (direction.Equals("Up"))
            rotateX = -spinSpeed;
        if (direction.Equals("Down"))
            rotateX = spinSpeed;
        if (direction.Equals("RollLeft"))
            rotateZ = spinSpeed;
        if (direction.Equals("RollRight"))
            rotateZ = -spinSpeed;
    }

    public void StopRotation()
    {
        rotateZ = 0;
        rotateY = 0;
        rotateX = 0;
    }

    public void Reset()
    {
        planeExterior.transform.rotation = new Quaternion();
        exteriorCamera.fieldOfView = 60;
    }
}
