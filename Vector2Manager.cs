using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector2Manager : MonoBehaviour
{

    Vector2[] direcciones = { Vector2.down, Vector2.up, Vector2.left, Vector2.right, Vector2.zero, Vector2.one };
    Vector2 direcionloca;
    public float velocidad;
  public  Transform posOtro;

    public enum TipoMovimiento { Lerp,MoveToward,Smooth}
    public TipoMovimiento movimiento;
    public float suaviza;
    public float entiempo;
    Vector2 velocidadSuavizada;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovimientoLoco());
        print("Angulo" + Vector2.Angle(Vector2.right, Vector2.up));
        Vector2 largo = new Vector2(10, 10);
        print("Magintud" + largo.magnitude);
        print("La magnitud antes de la raiz cuadrada" + largo.sqrMagnitude);
        //devuelve un vector cuya magitud maxima es el parametro 3
        //para las fuerzas
        print("vector con magintud maxima" + Vector2.ClampMagnitude(largo, 3));
        //Distancia entre el jugador y otro objeto
        //perpendicular 0
        //opuesto -1
        //misma 1
        print("producto escalar "+Vector2.Dot(new Vector2(1, 0), new Vector2(0, 1)));

        //Vector2.Max(new Vector2(1, 1), new Vector2(5, 5));
        //Vector2.Min(new Vector2(1, 1), new Vector2(4, 4));
    

    }

    // Update is called once per frame
    void Update()
    {
        print("Distancia" + Vector2.Distance(transform.position, posOtro.position));
        //transform.Translate(direcionloca*velocidad*Time.deltaTime);

        switch (movimiento)
        {
            case TipoMovimiento.Lerp:
              
                transform.position =Vector2.Lerp(transform.position, posOtro.position,Time.deltaTime*suaviza);
                break;
            case TipoMovimiento.MoveToward:
                transform.position = Vector2.MoveTowards(transform.position, posOtro.position, Time.deltaTime * suaviza);
                break;
            case TipoMovimiento.Smooth:
                transform.position = Vector2.SmoothDamp(transform.position, posOtro.position,ref velocidadSuavizada, entiempo);
                break;
        }
    }
        IEnumerator MovimientoLoco(){
        for (int i = 0; i < 100; i++)
        {
            direcionloca = direcciones[Random.Range(0, direcciones.Length)];
           
            yield return new WaitForSeconds(1);
        }
       
    }
}
