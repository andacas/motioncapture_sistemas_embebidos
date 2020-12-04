using UnityEngine;
using System;
using System.IO.Ports; //incluimos el namespace Sustem.IO.Ports

public class leer_serial : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM4", 9600);
    public string receivedstring;
    public mano mano_actual;
    public Vector3 rot;
    public Vector3 rot2;
    public string[] datos;
    public string[] datos_recibidos;
    public Material material;
    public float time = 0.05f;
    float tiempo_actual = 0;
    void Start()
    {
        stream.Open(); //Open the Serial Stream.
    }

    void FixedUpdate()
    {
        
        if (tiempo_actual>time)
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
        if (datos[0] != "" && datos[1] != "" && datos[2] != "" && datos[3] != "" && datos[4] != "") //Check if all values are recieved
        {
            datos_recibidos[0] = datos[0];
            datos_recibidos[1] = datos[1];
            datos_recibidos[2] = datos[2];
            datos_recibidos[3] = datos[3];
            datos_recibidos[4] = datos[4];
          //  print(datos_recibidos[0] + " y " + datos_recibidos[1] + " y " + datos_recibidos[2] + "y" + datos_recibidos[3] + "y" + datos_recibidos[4]);
            //datos_recibidos[2] = datos[2];
            //Read the information and put it in a vector3

            //Take the vector3 and apply it to the object this script is applied.
            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.
            stream.DiscardInBuffer();
        }
        
    }
    void convertir_datos()
    {
        int[] datos_convertidos = new int[5];
        int i = 0;
        while (i<5)
        {
            datos_convertidos[i] = Int32.Parse( datos_recibidos[i]);
            i++;
        }
        asignar_datos(datos_convertidos);
    }
    void asignar_datos(int[] datos_conv)
    {
        mano_actual.actualizar_dedo0(datos_conv[0]);
        mano_actual.actualizar_dedo1(datos_conv[1]);
        mano_actual.actualizar_dedo2(datos_conv[2]);
        mano_actual.actualizar_dedo3(datos_conv[3]);
        mano_actual.actualizar_dedo4(datos_conv[4]);
    }
}