using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPositions; // Array de game objects que contêm posição e rotação
    public GameObject leftArrow; // GameObject do canvas esquerdo
    public GameObject rightArrow; // GameObject do canvas direito
    public GameObject zoomTarget; // GameObject que ativa o zoom
    public GameObject zoomButton; // GameObject do botão de zoom
    public GameObject zoomGameObject; // GameObject para o qual a câmera se move ao usar o zoom
    private int currentIndex = 0; // Índice atual no array de posições da câmera
    private Vector3 lastPosition; // Última posição antes do zoom
    private Quaternion lastRotation; // Última rotação antes do zoom

    void Start()
    {
        // Desativar o botão de zoom inicialmente
        zoomButton.SetActive(false);

        // Salvar a posição e a rotação inicial
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        // Movimento para o próximo índice quando clicar no canvas direito
        if (Input.GetMouseButtonDown(0) && rightArrow != null && rightArrow == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
        {
            currentIndex = (currentIndex + 1) % cameraPositions.Length;
            MoveCameraToPosition(currentIndex);
        }
        
        // Movimento para o índice anterior quando clicar no canvas esquerdo
        if (Input.GetMouseButtonDown(0) && leftArrow != null && leftArrow == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
        {
            currentIndex = (currentIndex - 1 + cameraPositions.Length) % cameraPositions.Length;
            MoveCameraToPosition(currentIndex);
        }

        // Ativar/desativar zoom ao clicar no zoomTarget
        if (Input.GetMouseButtonDown(0) && zoomTarget != null && zoomTarget == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
        {
            ToggleZoom();
        }

        // Voltar para a última posição e rotação ao clicar no botão de zoom
        if (Input.GetMouseButtonDown(0) && zoomButton != null && zoomButton == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
        {
            ToggleZoom();
        }
    }

    // Método para mover a câmera para uma posição e rotação específicas no array
    void MoveCameraToPosition(int index)
    {
        transform.position = cameraPositions[index].position;
        transform.rotation = cameraPositions[index].rotation;
    }

    // Método para ativar/desativar o zoom
    void ToggleZoom()
    {
        if (!zoomButton.activeSelf)
        {
            // Salvar a posição e a rotação antes de ativar o zoom
            lastPosition = transform.position;
            lastRotation = transform.rotation;

            // Ativar o botão de zoom e mover a câmera para o zoomGameObject
            zoomButton.SetActive(true);
            transform.position = zoomGameObject.transform.position;
            transform.rotation = zoomGameObject.transform.rotation;

            // Desativar os canvases direito e esquerdo
            if (rightArrow != null)
                rightArrow.SetActive(false);
            if (leftArrow != null)
                leftArrow.SetActive(false);
        }
        else
        {
            // Voltar para a última posição e rotação
            transform.position = lastPosition;
            transform.rotation = lastRotation;

            // Desativar o botão de zoom e reativar os canvases direito e esquerdo
            zoomButton.SetActive(false);
            if (rightArrow != null)
                rightArrow.SetActive(true);
            if (leftArrow != null)
                leftArrow.SetActive(true);
        }
    }
}