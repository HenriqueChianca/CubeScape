using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    // Variáveis para armazenar os transform dos pontos de encaixe
    public Transform[] snapPoints;
    private Transform closestSnapPoint;

    // Variável para rastrear se o objeto está sendo arrastado
    public bool isDragging = false;

    // Propriedades para rastrear o snapPoint atual e original do objeto
    public Transform CurrentSnapPoint { get; set; }
    public Transform OriginalSnapPoint { get; set; }
    public int AssociatedInt { get; set; }

    // Referência ao DragAndDropManager
    public DragAndDropManager dragAndDropManager;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        // Define o snapPoint original do objeto
        OriginalSnapPoint = FindClosestSnapPoint();

        // Obtém a referência ao DragAndDropManager
        dragAndDropManager = FindObjectOfType<DragAndDropManager>();
    }

    public bool IsDragging
    {
        get { return isDragging; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Set the image as the first sibling to ensure it appears above other UI elements
        rectTransform.SetAsLastSibling();

        // Disable raycasting of the image while dragging
        canvasGroup.blocksRaycasts = false;

        // Set isDragging to true when the object is being dragged
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the image with the pointer
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Re-enable raycasting of the image
        canvasGroup.blocksRaycasts = true;

        // Find the closest snap point
        FindClosestSnapPoint();

        // Move the image to the closest snap point
        if (closestSnapPoint != null)
        {
            // Atualiza o snapPoint atual do objeto
            CurrentSnapPoint = closestSnapPoint;

            // Atualiza o snapPoint associado do objeto
            AssociatedInt = System.Array.IndexOf(snapPoints, closestSnapPoint);

            // Se o snapPoint atual for diferente do snapPoint original
            if (CurrentSnapPoint != OriginalSnapPoint)
            {
                // Encontra o objeto no snapPoint atual
                Draggable otherDraggable = FindDraggableAtSnapPoint(CurrentSnapPoint);

                // Se encontrou um objeto no snapPoint atual
                if (otherDraggable != null)
                {
                    // Move o outro objeto para o snapPoint original deste objeto
                    otherDraggable.MoveToSnapPoint(OriginalSnapPoint);
                }
            }

            // Move este objeto para o snapPoint mais próximo
            MoveToSnapPoint(CurrentSnapPoint);
        }

        // Set isDragging to false when the object is released
        isDragging = false;
    }

    private Transform FindClosestSnapPoint()
    {
        closestSnapPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(rectTransform.position, snapPoint.position);
            if (distance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = distance;
            }
        }
        return closestSnapPoint;
    }

    private Draggable FindDraggableAtSnapPoint(Transform snapPoint)
    {
        foreach (Draggable draggable in dragAndDropManager.draggables)
        {
            if (draggable.CurrentSnapPoint == snapPoint)
            {
                return draggable;
            }
        }
        return null;
    }

    private void MoveToSnapPoint(Transform snapPoint)
    {
        rectTransform.position = snapPoint.position;
        // Notifica o DragManager que o objeto foi solto
        dragAndDropManager.OnDraggableReleased(this, snapPoint);
    }

    public void MoveToOriginalSnapPoint()
    {
        MoveToSnapPoint(OriginalSnapPoint);
    }
}
