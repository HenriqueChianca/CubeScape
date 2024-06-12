using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimator : MonoBehaviour
{
    public Animator animator;
    public bool clicked = false;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        clicked = !clicked;
        
        if(clicked)
        {
            animator.SetBool("activate", true);
        }
        else
        {
            animator.SetBool("activate", false);
        }
        // Define a variável 'activate' do Animator como verdadeira
        
    }
}
