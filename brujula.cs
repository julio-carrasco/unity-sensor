using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class brujula : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text texto;
    void Start()
    {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Input.location.Start();
        
        Debug.Log(Input.location.status);
        Debug.Log(Input.compass.trueHeading);
        Debug.Log(Input.acceleration);
        Debug.Log(Input.gyro.rotationRate);
        Debug.Log(Input.location.lastData.latitude);
        Debug.Log(Input.location.lastData.longitude);
        Debug.Log(Input.location.lastData.altitude);
        Input.location.Stop();
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -Input.compass.trueHeading, 0), 0.5f);
        texto.text = $" V. Angular: {Input.gyro.rotationRate} \n Aceleracion: {Input.acceleration} \n Altitud: {Input.location.lastData.altitude} \n Gravedad: {Input.gyro.gravity} \n Longitud: {Input.location.lastData.longitude} \n Latitud: {Input.location.lastData.latitude}";
    }
}
