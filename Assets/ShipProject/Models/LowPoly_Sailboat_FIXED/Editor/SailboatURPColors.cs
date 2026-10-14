#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

// One-click material setup for the included OBJ meshes in Unity 6 URP.
// Each OBJ already contains UV coordinates pointing at one flat color swatch.
public static class SailboatURPColors
{
    [MenuItem("Tools/Sailboat/Apply URP Colors to Selected Parts")]
    private static void ApplyColors()
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader == null)
        {
            EditorUtility.DisplayDialog("Sailboat", "URP/Lit shader not found. Check that the project is using URP.", "OK");
            return;
        }

        string palettePath = null;
        foreach (string guid in AssetDatabase.FindAssets("sailboat_palette t:Texture2D"))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (Path.GetFileName(path) == "sailboat_palette.png")
            {
                palettePath = path;
                break;
            }
        }

        if (string.IsNullOrEmpty(palettePath))
        {
            EditorUtility.DisplayDialog("Sailboat", "Could not find sailboat_palette.png in Assets.", "OK");
            return;
        }

        Texture2D palette = AssetDatabase.LoadAssetAtPath<Texture2D>(palettePath);
        string folder = Path.GetDirectoryName(palettePath).Replace('\\', '/');
        string materialPath = folder + "/Sailboat_URP.mat";
        Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

        if (material == null)
        {
            material = new Material(shader) { name = "Sailboat_URP" };
            AssetDatabase.CreateAsset(material, materialPath);
        }
        else
        {
            material.shader = shader;
        }

        material.SetTexture("_BaseMap", palette);
        material.SetColor("_BaseColor", Color.white);
        EditorUtility.SetDirty(material);

        int updated = 0;
        foreach (GameObject selected in Selection.gameObjects)
        {
            foreach (MeshRenderer renderer in selected.GetComponentsInChildren<MeshRenderer>(true))
            {
                Undo.RecordObject(renderer, "Apply Sailboat URP Colors");
                int materialSlots = Mathf.Max(renderer.sharedMaterials.Length, 1);
                Material[] mats = new Material[materialSlots];
                for (int i = 0; i < materialSlots; i++)
                {
                    mats[i] = material;
                }

                renderer.sharedMaterials = mats;
                EditorUtility.SetDirty(renderer);
                updated++;
            }
        }

        AssetDatabase.SaveAssets();
        EditorUtility.DisplayDialog(
            "Sailboat",
            $"Assigned URP color palette to {updated} renderer(s). " +
            "If this says 0, select BoatHull and SailAssembly in the Hierarchy, not their OBJ assets.",
            "OK");
    }
}
#endif
