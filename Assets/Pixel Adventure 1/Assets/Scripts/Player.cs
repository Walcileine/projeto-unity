using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpspeed;
    private bool pulando = false;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;

        transform.Translate(x * Time.deltaTime, 0, 0);
        //transform.Translate(new Vector3(0, 0, 0));

        pulo();

        if (x != 0)
        {
            animator.SetBool("correndo", true);
        }
        else
        {
            animator.SetBool("correndo", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            pulando = false;
            animator.SetBool("pulando", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            pulando = true;
            animator.SetBool("pulando", true);
        }

    }

    private void pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !pulando)
        {
            rb.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
        }
    }

    private void morreu()
    {
        //GameObject go = GameObject.FindGameObjectsWithTag("Inicio");
        //transform.position = go.transform.position;
    }
}