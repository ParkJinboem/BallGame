using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManager manager;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio1;
    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio1.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Finish")
        {
            if(itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene(1);

            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
