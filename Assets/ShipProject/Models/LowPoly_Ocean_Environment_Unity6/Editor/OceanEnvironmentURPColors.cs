#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

// Assigns the included flat-color texture atlas to selected low-poly environment props.
// Editor-only utility; it is never included in the player's build.
public static class OceanEnvironmentURPColors
{
    [MenuItem("Tools/Ocean Environment/Apply URP Colors to Selected Props")]
    private static void ApplyColors()
    {
        Shader urpShader = Shader.Find("Universal Render Pipeline/Lit");
        if (urpShader == null)
        {
            EditorUtility.DisplayDialog("Ocean Environment",
                "Cannot find Universal Render Pipeline/Lit. Check that URP is installed and active.", "OK");
            return;
        }

        string texturePath = null;
        foreach (string guid in AssetDatabase.FindAssets("environment_palette t:Texture2D"))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (Path.GetFileName(path) == "environment_palette.png")
            {
                texturePath = path;
                break;
            }
        }

        if (string.IsNullOrEmpty(texturePath))
        {
            EditorUtility.DisplayDialog("Ocean Environment",
                "Cannot find environment_palette.png. Import all files from the ZIP together.", "OK");
            return;
        }

        TextureImporter importer = AssetImporter.GetAtPath(texturePath) as TextureImporter;
        if (importer != null &&
            (importer.filterMode != FilterMode.Point || importer.wrapMode != TextureWrapMode.Clamp || importer.mipmapEnabled))
        {
            importer.filterMode = FilterMode.Point;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.mipmapEnabled = false;
            importer.SaveAndReimport();
        }

        Texture2D palette = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
        string folder = Path.GetDirectoryName(texturePath).Replace('\\', '/');
        string materialPath = folder + "/OceanEnvironment_URP.mat";
        Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
        if (material == null)
        {
            material = new Material(urpShader) { name = "OceanEnvironment_URP" };
            AssetDatabase.CreateAsset(material, materialPath);
        }
        else
        {
            material.shader = urpShader;
        }

        material.SetTexture("_BaseMap", palette);
        material.SetColor("_BaseColor", Color.white);
        material.SetFloat("_Metallic", 0f);
        material.SetFloat("_Smoothness", 0.15f);
        EditorUtility.SetDirty(material);

        int changed = 0;
        foreach (GameObject target in Selection.gameObjects)
        {
            foreach (MeshRenderer renderer in target.GetComponentsInChildren<MeshRenderer>(true))
            {
                Undo.RecordObject(renderer, "Apply Ocean Environment URP Colors");
                int count = Mathf.Max(1, renderer.sharedMaterials.Length);
                Material[] materials = new Material[count];
                for (int i = 0; i < count; i++)
                    materials[i] = material;
                renderer.sharedMaterials = materials;
                EditorUtility.SetDirty(renderer);
                changed++;
            }
        }

        AssetDatabase.SaveAssets();
        EditorUtility.DisplayDialog("Ocean Environment",
            $"Material assigned to {changed} MeshRenderer(s). " +
            (changed == 0
                ? "Select the imported props in Hierarchy first, then run this command again."
                : "Ready to use in Unity 6 URP."), "OK");
    }
}
#endif
