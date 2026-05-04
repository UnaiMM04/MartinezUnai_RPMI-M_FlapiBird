using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    bool isAlive = true;

    //Componente RigidBody
    [SerializeField] Rigidbody2D rb;


    //Variables que gestionan su desplazamiento y rotación
    float jumpForce = 4;
    float rotationSpeed = 4;

    private void Start()
    {
        //Ponemos el tiempo a 1, por si venimos de la pantalla de GameOver, que lo pone a 0
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //Método que gestiona la interactividad del Player
    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Si estoy muerto
            if (!isAlive)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                rb.linearVelocity = Vector2.up * jumpForce;
            }
        }
        //Rotamos el player en función de su velocidad, para que se incline hacia arriba o hacia abajo
        transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * rotationSpeed);
    }

    //Detección de colisiones, si colisionamos con una tubería, la destruimos y perdemos salud, si colisionamos con el suelo, morimos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            //Si colisionamos con una tubería, la destruimos y perdemos salud
            Destroy(collision.gameObject);
            //Aquí tendremos que hacer lo necesario para perder escudo/saludo
        }
        else if (collision.gameObject.tag == "Floor")
        {
            //Si chocamos con el suelo, deberíamos morir
            
        }
    }

}
