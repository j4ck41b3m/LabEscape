using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarGranada : MonoBehaviour
{
    public GameObject granadaPrefab;
    public GameObject salida;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.G))
        {
            Lanzar();
        }
    }

    private void Lanzar()
    {
        GameObject nuevaGranada = Instantiate(granadaPrefab, salida.transform.position, salida.transform.rotation);
        nuevaGranada.GetComponent<Rigidbody>().AddForce(salida.transform.forward * 300 * Time.deltaTime, ForceMode.VelocityChange);
    }
}
