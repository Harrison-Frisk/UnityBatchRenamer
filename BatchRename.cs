using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

public class BatchRename : EditorWindow
{


    bool renameList = true;
    int startOfList = 1;
    string extensionChar = ".";

    string[] charOptions = new string[] {".","-","_"};
    int charIndex = 0;

    string newName = "";
    int objects = 0;


    [MenuItem("Tools/Batch Rename")]


    public static void ShowWindow() {
        GetWindow<BatchRename>("Batch Rename");
    }

    private void OnGUI() {

        objects = Selection.gameObjects.Length;



        EditorGUILayout.Space();
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("# of Objects to Edit: " + objects.ToString(), EditorStyles.boldLabel);
        GUILayout.EndHorizontal();


        EditorGUILayout.Space();


        renameList = EditorGUILayout.Foldout(renameList, "Rename List of Objects");
        if (renameList){
        GUILayout.BeginHorizontal();
        GUILayout.Label("Replace Name");
        newName = EditorGUILayout.TextField(newName);
        GUILayout.EndHorizontal();


        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Start of List");
        startOfList = EditorGUILayout.IntField(startOfList);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Extension Char");
        charIndex = EditorGUILayout.Popup(charIndex, charOptions);

        switch (charIndex){
            case 0:
                extensionChar = ".";
                break;
            case 1:
                extensionChar = "-";
                break;
            case 2:
                extensionChar = "_";
                break;
            default:
                break;
        }

        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rename!"))
        {
            Undo.RegisterCompleteObjectUndo(Selection.gameObjects,"Batch Rename");
            foreach(GameObject i in Selection.gameObjects)
            {
                i.name = newName + extensionChar + startOfList.ToString();
                startOfList++;
            }
        }
        GUILayout.EndHorizontal();

        }




        this.Repaint();

    }

}
