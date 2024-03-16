using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private bool moverEsquerda;
    private bool moverDireita;
    public float moverCameraSpeed = 5;
    private float horizontalMove;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PointerDownLeft()
    {
        moverEsquerda = true;
    }

    public void PointerUpLeft()
    {
        moverEsquerda = false;
    }

    public void PointerDownRightt()
    {
        moverDireita = true;
    }

    public void PointerUpRight()
    {
        moverDireita = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovimentando();
    }

    private void CameraMovimentando()
    {
        if (moverEsquerda)
        {
            horizontalMove = - moverCameraSpeed;
        }
        else if (moverDireita)
        {
            horizontalMove = moverCameraSpeed;
        }

        else
        {
            horizontalMove = 0;
        }
    }

    /* private Vector2 GetVelocity()
      {
          return moverCamera.velocity;
      } 

      private void FixedUpdate(Vector2 velocity)
      {
          velocity = new Vector2(horizontalMove, moverCamera.velocity.y);
      }
    */

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontalMove, rb.velocity.y);
    }

}
