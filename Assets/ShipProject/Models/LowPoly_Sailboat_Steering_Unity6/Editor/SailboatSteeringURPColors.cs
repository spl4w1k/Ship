#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

// Editor-only: applies the original sailboat color palette to the imported steering props.
public static class SailboatSteeringURPColors
{
    [MenuItem("Tools/Sailboat/Apply URP Colors to Steering Parts")]
    private static void ApplyColors()
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader == null)
        {
            EditorUtility.DisplayDialog("Steering models", "Universal Render Pipeline/Lit not found.", "OK");
            return;
        }

        string texturePath = null;
        foreach (string guid in AssetDatabase.FindAssets("sailboat_palette t:Texture2D"))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (Path.GetFileName(path) == "sailboat_palette.png" && path.Contains("LowPoly_Sailboat_Steering_Unity6"))
            {
                texturePath = path;
                break;
            }
        }
        if (string.IsNullOrEmpty(texturePath))
        {
            EditorUtility.DisplayDialog("Steering models", "Cannot find steering pack's sailboat_palette.png. Import the whole folder.", "OK");
            return;
        }

        TextureImporter importer = AssetImporter.GetAtPath(texturePath) as TextureImporter;
        if (importer != null && (importer.filterMode != FilterMode.Point || importer.wrapMode != TextureWrapMode.Clamp || importer.mipmapEnabled))
        {
            importer.filterMode = FilterMode.Point;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.mipmapEnabled = false;
            importer.SaveAndReimport();
        }
        Texture2D palette = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
        string folder = Path.GetDirectoryName(texturePath).Replace('\\', '/');
        string materialPath = folder + "/Steering_URP.mat";
        Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
        if (material == null)
        {
            material = new Material(shader) { name = "Steering_URP" };
            AssetDatabase.CreateAsset(material, materialPath);
        }
        else material.shader = shader;

        material.SetTexture("_BaseMap", palette);
        material.SetColor("_BaseColor", Color.white);
        material.SetFloat("_Metallic", 0f);
        material.SetFloat("_Smoothness", 0.18f);
        EditorUtility.SetDirty(material);

        int changed = 0;
        foreach (GameObject obj in Selection.gameObjects)
        {
            foreach (MeshRenderer renderer in obj.GetComponentsInChildren<MeshRenderer>(true))
            {
                Undo.RecordObject(renderer, "Apply steering URP colors");
                Material[] mats = new Material[Mathf.Max(1, renderer.sharedMaterials.Length)];
                for (int i=0; i<mats.Length; ++i) mats[i] = material;
                renderer.sharedMaterials = mats;
                EditorUtility.SetDirty(renderer);
                ++changed;
            }
        }
        AssetDatabase.SaveAssets();
        EditorUtility.DisplayDialog("Steering models", $"Assigned URP color material to {changed} mesh renderer(s).", "OK");
    }
}
#endif
