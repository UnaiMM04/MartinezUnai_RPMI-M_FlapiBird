using UnityEngine;

public class PipeMove : MonoBehaviour
{
    float speed = 4.0f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //Si la tubería se sale de la pantalla, la destruimos
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }


}
