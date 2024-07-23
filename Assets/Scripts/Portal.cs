using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public int nfase;
    public GameObject player, camaraA, camaraB;
    AudioSource sonido;
    //GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //player= GameObject.FindGameObjectWithTag("Player");
        sonido= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("¡Alerta de portal!");
            if(Vector3.Distance(player.transform.position, transform.position)> 0.2f){
                sonido.Play();
                camaraA.SetActive(false);
                player.GetComponent<ControlNave>().CambiarFase(nfase);
                player.transform.position= destination.transform.position;
                camaraB.SetActive(true);
            }
        }
    }
}
