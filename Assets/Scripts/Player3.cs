using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player3 : MonoBehaviour
{
    private Rigidbody _rd;
    public float Speed = 100f;
    private int _score = 0;
    public Text ScoreText;
    private bool _isDied = false;

    private void Awake()
    {
        _rd = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _rd.AddForce(new Vector3(h, 1, v) * -Speed * Time.fixedDeltaTime);

        if (_isDied && _score != 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _isDied = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            ++_score;
            Destroy(other.gameObject);

            if (_score != 5)
            {
                ScoreText.text = "Score: " + _score;
            }
            else
            {
                ScoreText.text = "You win!";
            }
        }

        if (other.gameObject.tag == "DestroyElement")
        {
            _isDied = true;
        }
    }
}
