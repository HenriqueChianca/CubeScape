using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAnim : MonoBehaviour
{
    public Animator animator;
    public string booleanParameterName = "isOpen"; // Nome do parâmetro booleano no Animator

    // Método chamado quando o botão da UI é clicado
    public void ToggleAnimatorBool()
    {
        // Obtém o valor atual da variável booleana
        bool currentState = animator.GetBool(booleanParameterName);

        // Inverte o valor
        bool newState = !currentState;

        // Define o novo valor da variável booleana no Animator
        animator.SetBool(booleanParameterName, newState);

        // Adiciona um log para verificar se o botão está funcionando corretamente
        Debug.Log("Button clicked. Animator bool toggled to: " + newState);
    }
}
