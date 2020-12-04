using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports; //incluimos el namespace Sustem.IO.Ports

public class SerialData : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM7", 9600);
    public string receivedstring;
    public Vector3 rot;
    public Vector3 rot2;
    public string[] datos;
    public string[] datos_recibidos;
    public mano mano_actual;
    public float time = 0.05f;
    float tiempo_actual = 0;
    void Start()
    {
        stream.Open(); //Open the Serial Stream.
    }

    void FixedUpdate()
    {
        if (tiempo_actual > time)
        {
            tiempo_actual = 0;
            recibir_datos();
            convertir_datos();


        }

        tiempo_actual += Time.deltaTime;
    }
    void recibir_datos()
    {
        
            receivedstring = stream.ReadLine(); //Read the information
            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

            datos = receivedstring.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
            if (datos[0] != "" && datos[1] != "" && datos[2] != "") //Check if all values are recieved
            {
                datos_recibidos[0] = datos[0];
                datos_recibidos[1] = datos[1];
                datos_recibidos[2] = datos[2];

                //print("x"+datos[0] + " y " + datos[1] + " y " + datos[2]);
                //datos_recibidos[2] = datos[2];
                //Read the information and put it in a vector3

                //Take the vector3 and apply it to the object this script is applied.
                stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
            }

        
    }
    void convertir_datos()
    {
        float[] datos_convertidos = new float[3];
        int i = 0;
        while (i < 3)
        {
            datos_convertidos[i] = float.Parse(datos_recibidos[i]);
            i++;
        }
        asignar_datos(datos_convertidos);
    }
    void asignar_datos(float[] datos_conv)
    {
        mano_actual.actualizar_muneca(datos_conv[0],datos_conv[1],datos_conv[2]);
        
        
    }
}
