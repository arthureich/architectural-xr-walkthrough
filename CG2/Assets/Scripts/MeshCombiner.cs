using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCombiner : MonoBehaviour
{
    // Adiciona um botão no menu de contexto do componente no Inspector
    [ContextMenu("Combine Meshes")]
    public void CombineMeshes()
    {
        // Pega todos os MeshFilters dos objetos filhos do objeto pai
        MeshFilter[] meshFilters = GetComponentsInParent<MeshFilter>(true);
        if (meshFilters.Length <= 1) return; // Não faz nada se não houver malhas para combinar

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            if (meshFilters[i].transform != transform) // Ignora a si mesmo
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            }
            i++;
        }

        // Cria uma nova malha e combina tudo nela
        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine, true, true);

        // Atribui a nova malha combinada aos componentes deste objeto
        GetComponent<MeshFilter>().sharedMesh = combinedMesh;
        GetComponent<MeshCollider>().sharedMesh = combinedMesh;

        // Opcional: Desativa o renderer para que não seja desenhado duas vezes
        GetComponent<MeshRenderer>().enabled = false;

        Debug.Log("Malhas combinadas com sucesso!");
    }
}