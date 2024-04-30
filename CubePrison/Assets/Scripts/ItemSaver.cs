using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaver : MonoBehaviour
{
    private static ItemSaver instance; // Referência estática para a única instância da classe

    // Chave para armazenar a lista de strings
    public const string StringListKey = "StringList";

    // Número máximo de strings na lista
    public const int MaxStringCount = 5;

    // Lista de strings
    public List<string> stringList = new List<string>();

    private void Awake()
    {
        // Garantir que apenas uma instância da classe exista
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método estático para acessar a instância do singleton
    public static ItemSaver GetInstance()
    {
        return instance;
    }

    // Adicionar uma string à lista
    public void AddString(string newString)
    {
        // Verificar se a lista já contém o máximo de strings permitido
        if (stringList.Count >= MaxStringCount)
        {
            Debug.LogWarning("A lista de strings já atingiu o número máximo.");
            return;
        }

        // Adicionar a nova string à lista
        stringList.Add(newString);

        // Salvar a lista atualizada
        SaveStringList();
    }

    // Remover uma string da lista pelo índice
    public void RemoveString(int index)
    {
        // Verificar se o índice está dentro dos limites da lista
        if (index < 0 || index >= stringList.Count)
        {
            Debug.LogWarning("Índice inválido.");
            return;
        }

        // Remover a string da lista
        stringList.RemoveAt(index);

        // Salvar a lista atualizada
        SaveStringList();
    }

    // Salvar a lista de strings no PlayerPrefs
    private void SaveStringList()
    {
        PlayerPrefs.SetString(StringListKey, string.Join(",", stringList.ToArray()));
        PlayerPrefs.Save(); // Salva imediatamente as alterações feitas
        Debug.Log("Lista de strings salva.");
    }

    // Carregar a lista de strings do PlayerPrefs
    private void LoadStringList()
    {
        stringList.Clear(); // Limpar a lista atual para evitar duplicatas

        if (PlayerPrefs.HasKey(StringListKey))
        {
            string[] savedStrings = PlayerPrefs.GetString(StringListKey).Split(',');

            // Adicionar as strings salvas à lista
            foreach (string str in savedStrings)
            {
                stringList.Add(str);
            }
        }

        Debug.Log("Lista de strings carregada.");
    }
}