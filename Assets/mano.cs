using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mano : MonoBehaviour
{
    public Transform[] dedo_0;// modificar rotacion en eje z Abierto:
    public Transform[] dedo_1;
    public Transform[] dedo_2;
    public Transform[] dedo_3;
    public Transform[] dedo_4;
    public Transform muneca;
    // Start is called before the first frame update
    void Start()
    {
        
        dedo_0[0].localRotation = Quaternion.Euler(dedo_0[0].rotation.x, dedo_0[0].rotation.y, 50);
        dedo_0[1].localRotation= Quaternion.Euler(dedo_0[1].rotation.x, dedo_0[1].rotation.y, 90);

        dedo_1[0].localRotation = Quaternion.Euler(-70, dedo_1[0].rotation.y, dedo_1[0].rotation.z);
        dedo_1[1].localRotation = Quaternion.Euler(-100, dedo_1[1].rotation.y, dedo_1[1].rotation.z);
        dedo_1[2].localRotation = Quaternion.Euler(-90, dedo_1[2].rotation.y, dedo_1[2].rotation.z);

        dedo_2[0].localRotation = Quaternion.Euler(-70, dedo_2[0].rotation.y, dedo_2[0].rotation.z);
        dedo_2[1].localRotation = Quaternion.Euler(-100, dedo_2[1].rotation.y, dedo_2[1].rotation.z);
        dedo_2[2].localRotation = Quaternion.Euler(-90, dedo_2[2].rotation.y, dedo_2[2].rotation.z);

        dedo_3[0].localRotation = Quaternion.Euler(-70, dedo_3[0].rotation.y, dedo_3[0].rotation.z);
        dedo_3[1].localRotation = Quaternion.Euler(-100, dedo_3[1].rotation.y, dedo_3[1].rotation.z);
        dedo_3[2].localRotation = Quaternion.Euler(-90, dedo_3[2].rotation.y, dedo_3[2].rotation.z);

        dedo_4[0].localRotation = Quaternion.Euler(-70, dedo_4[0].rotation.y, dedo_4[0].rotation.z);
        dedo_4[1].localRotation = Quaternion.Euler(-100, dedo_4[1].rotation.y, dedo_4[1].rotation.z);
        dedo_4[2].localRotation = Quaternion.Euler(-90, dedo_4[2].rotation.y, dedo_4[2].rotation.z);
    }

    public void actualizar_dedo1(float medicion_actual)
    {
        dedo_1[0].localRotation = Quaternion.Euler(actualizar_segmento(700,960,-18,-70,medicion_actual), dedo_1[0].rotation.y, dedo_1[0].rotation.z);
        dedo_1[1].localRotation = Quaternion.Euler(actualizar_segmento(700, 960, -18, -100, medicion_actual), dedo_1[1].rotation.y, dedo_1[1].rotation.z);
        dedo_1[2].localRotation = Quaternion.Euler(actualizar_segmento(700, 960, -2, -90, medicion_actual), dedo_1[2].rotation.y, dedo_1[2].rotation.z);


    }
    public void actualizar_dedo2(float medicion_actual)
    {
        dedo_2[0].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -18, -70, medicion_actual), dedo_2[0].rotation.y, dedo_2[0].rotation.z);
        dedo_2[1].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -18, -100, medicion_actual), dedo_2[1].rotation.y, dedo_2[1].rotation.z);
        dedo_2[2].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -2, -90, medicion_actual), dedo_2[2].rotation.y, dedo_2[2].rotation.z);
    }
    public void actualizar_dedo3(float medicion_actual)
    {
        dedo_3[0].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -18, -70, medicion_actual), dedo_3[0].rotation.y, dedo_3[0].rotation.z);
        dedo_3[1].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -18, -100, medicion_actual), dedo_3[1].rotation.y, dedo_3[1].rotation.z);
        dedo_3[2].localRotation = Quaternion.Euler(actualizar_segmento(700, 950, -2, -90, medicion_actual), dedo_3[2].rotation.y, dedo_3[2].rotation.z);


    }
    public void actualizar_dedo4(float medicion_actual)
    {
        dedo_4[0].localRotation = Quaternion.Euler(actualizar_segmento(700, 960, -18, -70, medicion_actual), dedo_4[0].rotation.y, dedo_4[0].rotation.z);
        dedo_4[1].localRotation = Quaternion.Euler(actualizar_segmento(700, 960, -18, -100, medicion_actual), dedo_4[1].rotation.y, dedo_4[1].rotation.z);
        dedo_4[2].localRotation = Quaternion.Euler(actualizar_segmento(700, 960, -2, -90, medicion_actual), dedo_4[2].rotation.y, dedo_4[2].rotation.z);


    }
    public void actualizar_dedo0(float medicion_actual)
    {
        dedo_0[0].localRotation = Quaternion.Euler(dedo_0[0].rotation.x, dedo_0[0].rotation.y, actualizar_segmento(700, 880, 14, 50, medicion_actual));
        dedo_0[1].localRotation = Quaternion.Euler(dedo_0[1].rotation.x, dedo_0[1].rotation.y,  actualizar_segmento(700, 880, 4, 90, medicion_actual));


    }
    public float actualizar_segmento(float med_min, float med_max,float ang_min,float ang_max,float med_actual)
    {
        return ang_min - ((ang_min - ang_max) / (med_min - med_max)) * (med_min - med_actual);
    }
    public void actualizar_muneca(float angx , float angy,float angz)
    {
        muneca.rotation = Quaternion.Euler(angx, angy, angz);
    }
}
