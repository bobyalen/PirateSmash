using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
        public float speed;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

            // Try out this delta time method??
            //rb2d.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
}
