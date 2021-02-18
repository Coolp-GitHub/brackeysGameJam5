using UnityEngine;

namespace Enemy
{
    public class Patrol : MonoBehaviour
    {

        public float speed = 0.2f;

        public bool moveRight = true;

        public Transform groundDetection;

    

        private void Update()
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime));



            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);


        

            if (groundInfo.collider == false)
                if (moveRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    moveRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    moveRight = true;
                }

        }
    }
}
