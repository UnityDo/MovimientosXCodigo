using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveyRota : MonoBehaviour
{
    public float velocidad;
    public float velocidadGiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * velocidad,Space.World);
      //  transform.Rotate(0, 0, velocidadGiro * Time.deltaTime);
       // transform.Rotate(new Vector3(0, 0, 1),Time.deltaTime*velocidadGiro);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * velocidadGiro), Space.Self);
    }
}
