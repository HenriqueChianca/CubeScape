using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropManager : MonoBehaviour
{
    // Lista de todos os objetos arrastáveis
    public List<Draggable> draggables = new List<Draggable>();

    // Método para adicionar um objeto arrastável à lista
    public void AddDraggable(Draggable draggable)
    {
        if (!draggables.Contains(draggable))
        {
            draggables.Add(draggable);
        }
    }

    // Método para remover um objeto arrastável da lista
    public void RemoveDraggable(Draggable draggable)
    {
        if (draggables.Contains(draggable))
        {
            draggables.Remove(draggable);
        }
    }

    // Método chamado quando um objeto é solto
    public void OnDraggableReleased(Draggable releasedDraggable, Transform newSnapPoint)
    {
        // Se o novo ponto de encaixe estiver vazio, mova o releasedDraggable para lá
        if (releasedDraggable.CurrentSnapPoint == null)
        {
            releasedDraggable.CurrentSnapPoint = newSnapPoint;
            releasedDraggable.transform.position = releasedDraggable.CurrentSnapPoint.position;
            return;
        }

        // Verifica se algum outro objeto está próximo ao novo ponto de encaixe
        foreach (Draggable draggable in draggables)
        {
            if (draggable != releasedDraggable && Vector3.Distance(draggable.transform.position, newSnapPoint.position) < 1f)
            {
                // Troca os pontos de encaixe entre os objetos
                Transform tempSnapPoint = draggable.CurrentSnapPoint;
                draggable.CurrentSnapPoint = releasedDraggable.CurrentSnapPoint;
                releasedDraggable.CurrentSnapPoint = tempSnapPoint;

                // Reposiciona os objetos nos pontos de encaixe atualizados
                draggable.transform.position = draggable.CurrentSnapPoint.position;
                releasedDraggable.transform.position = releasedDraggable.CurrentSnapPoint.position;

                return;
            }
        }

        // Se nenhum outro objeto estiver próximo, mova apenas o releasedDraggable para o novo ponto de encaixe
        releasedDraggable.CurrentSnapPoint = newSnapPoint;
        releasedDraggable.transform.position = releasedDraggable.CurrentSnapPoint.position;
    }
}
