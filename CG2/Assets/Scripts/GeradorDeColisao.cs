using UnityEngine;
using System.Collections.Generic;

public class GeradorDeColisao : MonoBehaviour
{
    // O nome do objeto que guardará a colisão
    private string nomeObjetoColisao = "ColisaoCombinada";

    [ContextMenu("1. GERAR COLISÃO DO PRÉDIO")]
    private void GerarColisao()
    {
        // Garante que estamos trabalhando com um objeto 'desempacotado' do prefab
        // Isso resolve o erro "não posso atribuir o prefab"
        #if UNITY_EDITOR
        UnityEditor.PrefabUtility.UnpackPrefabInstance(gameObject, UnityEditor.PrefabUnpackMode.Completely, UnityEditor.InteractionMode.AutomatedAction);
        #endif

        // --- Encontra todos os MeshFilters nos filhos deste objeto ---
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        List<CombineInstance> combine = new List<CombineInstance>();

        foreach (var meshFilter in meshFilters)
        {
            // Pula o MeshFilter do próprio objeto pai, se ele tiver um
            if (meshFilter.gameObject == this.gameObject) continue;

            CombineInstance ci = new CombineInstance();
            ci.mesh = meshFilter.sharedMesh;
            ci.transform = meshFilter.transform.localToWorldMatrix;
            combine.Add(ci);
        }

        if (combine.Count == 0)
        {
            Debug.LogError("Nenhuma malha encontrada nos objetos filhos para combinar!");
            return;
        }
        
        // --- Prepara o objeto que vai receber a colisão ---
        
        // Procura se o objeto de colisão já existe e o deleta para gerar um novo
        Transform colisaoExistente = transform.Find(nomeObjetoColisao);
        if (colisaoExistente != null)
        {
            DestroyImmediate(colisaoExistente.gameObject);
        }

        // Cria o novo objeto de colisão
        GameObject objetoDeColisao = new GameObject(nomeObjetoColisao);
        objetoDeColisao.transform.SetParent(this.transform);
        objetoDeColisao.transform.localPosition = Vector3.zero;

        // Adiciona os componentes necessários a ele
        MeshFilter mf = objetoDeColisao.AddComponent<MeshFilter>();
        MeshCollider mc = objetoDeColisao.AddComponent<MeshCollider>();
        // Adicionamos um MeshRenderer para evitar alguns bugs, mas o deixamos invisível
        objetoDeColisao.AddComponent<MeshRenderer>().enabled = false;

        // --- Combina as malhas e aplica no objeto de colisão ---
        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine.ToArray(), true, true);
        
        mf.sharedMesh = combinedMesh;
        mc.sharedMesh = combinedMesh;

        Debug.Log($"COLISÃO GERADA! {combine.Count} malhas foram combinadas no objeto '{nomeObjetoColisao}'.");
    }

    [ContextMenu("2. Remover Objeto de Colisão")]
    private void RemoverColisao()
    {
        Transform colisaoExistente = transform.Find(nomeObjetoColisao);
        if (colisaoExistente != null)
        {
            DestroyImmediate(colisaoExistente.gameObject);
            Debug.Log("Objeto de colisão removido.");
        }
    }
}