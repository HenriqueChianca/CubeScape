using UnityEngine;
using UnityEngine.UI;

public class CameraRotate : MonoBehaviour
{
    public Animator cameraAnimator;
    public Button leftButton;
    public Button rightButton;
    public Button upButton;
    public Button downButton;

    private int currentDirection = 0; // 0 = frente, 1 = direita, 2 = esquerda, 3 = trás, 4 = teto

    void Start()
    {
        // Atribui ouvintes para os cliques nos botões
        leftButton.onClick.AddListener(RotateLeft);
        rightButton.onClick.AddListener(RotateRight);
        upButton.onClick.AddListener(RotateUp);
        downButton.onClick.AddListener(RotateDown);
    }

    void RotateLeft()
    {
        if (currentDirection == 4)
        {
            // Teto está visível, mapeie para a esquerda
            currentDirection = 2;
            downButton.gameObject.SetActive(false); // Desativa o botão para baixo
        }
        else
        {
            // Rotação lateral normal
            currentDirection = (currentDirection == 0) ? 2 : (currentDirection == 2) ? 3 : (currentDirection == 3) ? 1 : 0;
        }

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateRight()
    {
        if (currentDirection == 4)
        {
            // Teto está visível, mapeie para a direita
            currentDirection = 1;
            downButton.gameObject.SetActive(false); // Desativa o botão para baixo
        }
        else
        {
            // Rotação lateral normal
            currentDirection = (currentDirection == 0) ? 1 : (currentDirection == 1) ? 3 : (currentDirection == 3) ? 2 : 0;
        }

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateUp()
    {
        // Rotação para o teto
        currentDirection = (currentDirection != 4) ? 4 : (currentDirection == 4) ? 3 : 0;
        downButton.gameObject.SetActive(true); // Ativa o botão para baixo

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }

    void RotateDown()
    {
        // Rotação para baixo (voltar à visualização lateral)
        currentDirection = 0;
        downButton.gameObject.SetActive(false); // Desativa o botão para baixo

        // Atualiza o parâmetro do Animator para refletir a nova orientação da câmera
        cameraAnimator.SetInteger("NumeroParede", currentDirection);
    }
}
