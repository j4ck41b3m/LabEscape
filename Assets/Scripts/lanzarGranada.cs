using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarGranada : MonoBehaviour
{
    public GameObject granadaPrefab;
    public GameObject salida;
    public int fuerza;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (GameManager.instance.granadas > 0)
            {
                Lanzar();
            }
            
        }
    }

    private void Lanzar()
    {
        GameManager.instance.granadas--;

        GameObject nuevaGranada = Instantiate(granadaPrefab, salida.transform.position, salida.transform.rotation);
        nuevaGranada.GetComponent<Rigidbody>().AddForce(salida.transform.forward * fuerza * Time.deltaTime, ForceMode.VelocityChange);
    }
}
