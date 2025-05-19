using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Champ_Vison_IA_Arc))]
public class Champ_Vison_IA : Editor
{
    void OnSceneGUI()
    {
        Champ_Vison_IA_Arc t = (Champ_Vison_IA_Arc)target;
        Handles.color = new Color(1, 0.1f, 0.1f, 0.2f);

        // Utilisation correcte de DrawWireArc pour afficher l'arc de vision
        Handles.DrawSolidArc(t.transform.position, Vector3.up, -t.transform.right, 180, t.visoionArea);
    }
}