using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayerManager : MonoBehaviour
{
    bool isAlive = true;
    int maxLives = 3;
    int lives = 3;
    int shield = 100;
    int healt = 100;
    int dano = 25;

    //Componente RigidBody
    [SerializeField] Rigidbody2D rb;


    //Variables que gestionan su desplazamiento y rotación
    float jumpForce = 4;
    float rotationSpeed = 4;
    float limitUp = 4.5f;

    [SerializeField] HudManager hudManager;

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

            if (limitUp >= 0) 
            { 

            }
        }
        //Rotamos el player en función de su velocidad, para que se incline hacia arriba o hacia abajo
        transform.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.y * rotationSpeed);
    }


    void StartGame()
    {
        Time.timeScale += 1f;
        lives = maxLives;
        hudManager.UpdateLives(lives);
        healt = 100;
        hudManager. UpdateHealth(healt);
        hudManager.PrintMessage("Bajame dos tonitos");

    }

    void Gameover()
    {
        if (lives <= 0)
            isAlive = false;

    }



    //Detección de colisiones, si colisionamos con una tubería, la destruimos y perdemos salud, si colisionamos con el suelo, morimos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            //Si colisionamos con una tubería, la destruimos y perdemos salud
            Destroy(collision.gameObject);
            //Aquí tendremos que hacer lo necesario para perder escudo/saludo
            hudManager.PrintMessage("Malo");
            shield -= dano;
            hudManager.UpdateHealth(shield);
            if (shield <= 0) ;
            {
                lives--;
                hudManager.UpdateLives(lives);
                if (lives <= 0) ;
                {
                    isAlive = false;
                }
            }
                

        }
        else if (collision.gameObject.tag == "Floor")
        {
            //Si chocamos con el suelo, deberíamos morir
            isAlive = false;
            
        }
    }

   
    

}
