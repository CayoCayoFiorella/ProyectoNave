using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlNave : MonoBehaviour
{

    Rigidbody rigidbody;
    Transform transform;
    public AudioSource sonidoImpulso, sonidoChoque, sonidoCombustible, sonidoMineral, sonidoColeccionable, sonidoSuperComb, musicaFondo, sonidoPerder;
    bool key;
    bool activeFixedPpdate = true;
    bool detenido= false;
    bool batalla= false;
    float gasto= 0.015f;
    public int nfase;
    public ControlBarra controlbarra;
    public SistemaGuardado sistemaGuardado;
    public MenuPerdiste menuPerdiste;
    public GameObject impulso;

    public float[] inicio = { -3.0f,75.0f ,151.5f};

    float umbralVelocidad = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        key= false;
        //controlbarra.CambiarValor(20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarInput();
        //Debug.Log(Time.deltaTime + "seg. " + (1.0f / Time.deltaTime) + "FPS");
    }

    void FixedUpdate() {
        if(activeFixedPpdate){
            float lim= inicio[nfase];
            rigidbody.position= new Vector3(Mathf.Clamp(rigidbody.position.x,lim,lim+52),Mathf.Clamp(rigidbody.position.y,-2.6f,29.5f),rigidbody.position.z);
            
            // Obtén la rotación actual de la nave
            Quaternion currentRotation = rigidbody.rotation;

            // Restringe la rotación en los ejes X e Y
            float clampedX = Mathf.Clamp(currentRotation.eulerAngles.x, 0f, 0f);
            float clampedY = Mathf.Clamp(currentRotation.eulerAngles.y, 0f, 0f);

            // Crea un nuevo quaternion con las restricciones
            Quaternion clampedRotation = Quaternion.Euler(clampedX, clampedY, currentRotation.eulerAngles.z);

            // Asigna la nueva rotación a la nave
            rigidbody.rotation = clampedRotation;
        }        
    }

    private void ProcesarInput(){
        Propulsion();
        Rotacion();
        Verificar();     
    }

    private void Propulsion(){
        if(Input.GetKey(KeyCode.Space) && activeFixedPpdate){
            //rigidbody.freezeRotation= true;
            float combustible= controlbarra.GetValor();
            if(combustible >0){
                rigidbody.AddRelativeForce(Vector3.up); //Cambiar
                impulso.SetActive(true);
                controlbarra.Gastar(gasto);
                if(!sonidoImpulso.isPlaying){
                    sonidoImpulso.Play();
                } 
            } else{
                sonidoImpulso.Stop();
                impulso.SetActive(false);
                print("No tienes combustible");
            }                     
        }
        else{
            sonidoImpulso.Stop();
            impulso.SetActive(false);
        }
        rigidbody.freezeRotation= false;
    }

    private void Rotacion()
    {
        float rotationSpeed = 100f; 
        float torque = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            torque = -rotationSpeed;
            //rigidbody.AddTorque(Vector3.forward * torque * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            torque = rotationSpeed;
            //rigidbody.AddTorque(Vector3.back * torque * Time.deltaTime);
        }
        rigidbody.AddTorque(Vector3.forward * torque * Time.deltaTime);
    }

    private void Verificar(){
        float combustible= controlbarra.GetValor();
        if(combustible <= 0 && !detenido){
            Vector3 velocidad = rigidbody.velocity;           

            // Calcula la magnitud de la velocidad
            float magnitudVelocidad = velocidad.magnitude;

            // Compara la magnitud de la velocidad con el umbral
            if (magnitudVelocidad < umbralVelocidad)
            {
                // El objeto casi no se está moviendo
                
                detenido= true;
                musicaFondo.Stop();
                sonidoPerder.Play();
                print("Detenido");
                menuPerdiste.Mostrar();
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        rigidbody.freezeRotation = true;
        GameObject colisionador=collision.gameObject;

        if(colisionador.CompareTag("ColisionPeligrosa")){
            print("Chocaste");
            sistemaGuardado.QuitarPuntaje(20);
            //sonido2.Stop();
            sonidoChoque.Play();
            Vector3 empuje= transform.position - colisionador.transform.position;
            rigidbody.AddForce(150*empuje);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        RigidbodyConstraints constraints = rigidbody.constraints;
        constraints &= ~RigidbodyConstraints.FreezeRotationZ;

        // Aplica las nuevas restricciones al Rigidbody
        rigidbody.constraints = constraints;
    }

    public void Continuar(Vector3 inicio, Vector3 direccion){
        StartCoroutine(Salida());
        rigidbody.Sleep();
        transform.position= inicio;
        transform.localScale = new Vector3(2f, 2f, 2f);
        activeFixedPpdate= false;        
        rigidbody.constraints = RigidbodyConstraints.None;
        Quaternion newRotation = Quaternion.LookRotation(direccion)* Quaternion.Euler(90f, 0f, 0f);
        transform.rotation = newRotation;
        rigidbody.AddForce(30*direccion);
        impulso.SetActive(true);        
    }

    public bool HasKey(){
        return key;
    }

    public void GetKey(){
        sonidoMineral.Play();
        print("Obtuviste la llave");
        key= true;
    }

    public void GetCombustible(){
        sonidoCombustible.Play();
        print("Recarga de combustible");
        controlbarra.CambiarValor(100.0f);
    }

    public void GetColeccionable(int n){
        sonidoColeccionable.Play();
        print("Obtuviste el coleccionable");
        sistemaGuardado.PutColeccionable(n);
        sistemaGuardado.AgregarPuntaje(100);
    }

    public void GetSuperCombustible(){
        sonidoSuperComb.Play();
        print("Super Combustible");
        gasto/= 3;
        controlbarra.CambiarValor(100.0f);
    }

    public void GetNormalCombustible(){
        print("Super Combustible");
        gasto*= 3;
    }

    public void AplicarFuerza(Vector3 fuerza){
        rigidbody.AddForce(fuerza);
    }

    IEnumerator Salida(){
        yield return new WaitForSeconds(2.0f);
        //Time.timeScale= 0f; //Descomentar esto cuando se ponga la pantalla de salida
        //Pantalla de Salida
        int nivel= SceneManager.GetActiveScene().buildIndex-3;
        if(sistemaGuardado.puntaje > sistemaGuardado.datosJuego.puntajeMax[nivel]){
            sistemaGuardado.datosJuego.puntajeMax[nivel]= sistemaGuardado.puntaje;
        }
        nivel++;
        sistemaGuardado.nivel= nivel;
        sistemaGuardado.GuardarDatos(nivel-1); //guardar al final
        if(nivel < 5 ){
            SceneManager.LoadScene(nivel + 3);
        }else{
            SceneManager.LoadScene(1);
        }
    }
    public void CambiarFase(int n){
        rigidbody.Sleep();
        nfase= n;
    }

    public void CambiarTema(){
        if(batalla){
            batalla= false;
            musicaFondo.Play();
        }else{
            batalla= true;
            musicaFondo.Stop();
        }
    }
}