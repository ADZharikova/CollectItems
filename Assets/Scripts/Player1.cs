using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    private Rigidbody _rd;
    public float Speed = 100f;
    private int _score = 0;
    public Text ScoreText;

    private void Awake()
    {
        _rd = GetComponent<Rigidbody>();
        ScoreText.text = "Score: " + _score;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _rd.AddForce(new Vector3(h, 1, v) * -Speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space) && _score == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
                ScoreText.text = "You win!\n\nTab SPACE to continue";
            }
        }
    }
}
