using UnityEngine;
using UnityEditor;

public class ReactiveToolEditor : EditorWindow
{
    [MenuItem("Reactive/GenerationTool")]
    private static void Init()
    {
        ReactiveToolEditor window = EditorWindow.GetWindow<ReactiveToolEditor>();
        window.Show();
    }

    private string m_className = "";
    private string m_reactiveFolder = "ReactiveExtension";
    private bool m_makeConstProperty = true;
    private bool m_makeReactiveProperty = true;
    private bool m_makeReactiveEvent = true;

    private void OnGUI()
    {
        m_className = EditorGUILayout.TextField("Class name", m_className);
        m_reactiveFolder = EditorGUILayout.TextField("Path", m_reactiveFolder);
        m_makeConstProperty = EditorGUILayout.Toggle("Generate Const Property", m_makeConstProperty);
        m_makeReactiveProperty = EditorGUILayout.Toggle("Generate Reactive Property", m_makeReactiveProperty);
        m_makeReactiveEvent = EditorGUILayout.Toggle("Generate Event", m_makeReactiveEvent);

        EditorGUI.BeginDisabledGroup(true); 
        EditorGUILayout.LabelField("Generated preview:");
        if (m_makeConstProperty)
        {
            string fileName = GetFullPath("ConstProperties", GetConstFileName());
            EditorGUILayout.LabelField(fileName);
            EditorGUILayout.TextArea(GetConstFile());
        }
        if (m_makeReactiveProperty)
        {
            string fileName = GetFullPath("Properties", GetReactivePropertyFileName());
            EditorGUILayout.LabelField(fileName);
            EditorGUILayout.TextArea(GetReactivePropertyFile());
        }
        if (m_makeReactiveEvent)
        {
            string fileName = GetFullPath("Events", GetReactiveEventFileName());
            EditorGUILayout.LabelField(fileName);
            EditorGUILayout.TextArea(GetReactiveEventFile());
        }
        EditorGUI.EndDisabledGroup();
        if (m_className.Equals(""))
            EditorGUI.BeginDisabledGroup(true);
        if (GUILayout.Button("Generate"))
            Generate();
        if (m_className.Equals(""))
            EditorGUI.EndDisabledGroup();
    }

    private void Generate()
    {
        if (m_className.Equals(""))
        {
            Debug.LogWarning("need a class name!");
            return;
        }
        if (m_makeConstProperty)
            GenerateConst();
        if (m_makeReactiveEvent)
            GenerateReactiveEvent();
        if (m_makeReactiveProperty)
            GenerateReactiveProperty();
        AssetDatabase.Refresh();
    }

    private string GetFullPath(string folder, string fileName)
    {
        return Application.dataPath + "/" + m_reactiveFolder + "/" + folder + "/" + fileName;
    }

    private string GetConstFileName()
    {
        return "ConstProperty" + m_className + ".cs";
    }

    private string GetReactivePropertyFileName()
    {
        return "Reactive" + m_className + ".cs";
    }

    private string GetReactiveEventFileName()
    {
        return "ReactiveEvent" + m_className + ".cs";
    }

    private void CreateFile(string file, string fileName, string folder)
    {
        string fullPath = GetFullPath(folder, fileName);
        Debug.Log("creating: " + fullPath);
        try
        {
            System.IO.File.WriteAllText(fullPath, file);

        }
        catch { Debug.LogWarning("something went wrong creating file!"); }
        Debug.Log("done");
    }


    private void GenerateConst()
    {
        CreateFile(GetConstFile(), GetConstFileName(), "ConstProperties");
    }


    private void GenerateReactiveProperty()
    {
        CreateFile(GetReactivePropertyFile(), GetReactivePropertyFileName(), "Properties");
    }


    private void GenerateReactiveEvent()
    {
        CreateFile(GetReactiveEventFile(), GetReactiveEventFileName(), "Events");
    }

    private string GetConstFile()
    {
        return
            "using UnityEngine;\n" +
            "\n" +
            "[CreateAssetMenu(menuName = \"Reactive/Const/" + m_className + "\", fileName = \"C_{name}_" + m_className + "\")]\n" +
            "public class ConstProperty" + m_className + " : ConstPropertyBase<" + m_className + ">\n" +
            "{\n" +
            "}\n" +
            "\n";
    }

    private string GetReactiveEventFile()
    {
        return
            "using UnityEngine;\n" +
            "\n" +
            "[CreateAssetMenu(menuName = \"Reactive/Events/" + m_className + "\", fileName = \"R_E_{name}_" + m_className + "\")]\n" +
            "public class ReactiveEvent" + m_className + " : ReactiveEventBase<" + m_className + ">\n" +
            "{\n" +
            "}\n" +
            "\n";
    }
    private string GetReactivePropertyFile()
    {
        return
            "using UnityEngine;\n" +
            "\n" +
            "[CreateAssetMenu(menuName = \"Reactive/Data/" + m_className + "\", fileName = \"R_P_{name}_" + m_className + "\")]\n" +
            "public class Reactive" + m_className + " : ReactivePropertyBase<" + m_className + ">\n" +
            "{\n" +
            "}\n" +
            "\n";
    }
}
