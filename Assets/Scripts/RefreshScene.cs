using System.IO;
using UnityEditor;
using UnityEngine;

public class RefreshScene : Editor
{

    private static readonly string scenePath = "Scenes";
    // ��Ӳ˵�ѡ��
    [MenuItem("Tool/RefreshScene")]
    static void RefreshAllScene()
    {
        // ���ó��� *.unity ·��
        string path = Path.Combine(Application.dataPath, scenePath);
        // ������ȡĿ¼������ .unity �ļ�
        string[] files = Directory.GetFiles(path, "*.unity", SearchOption.AllDirectories);

        // ���� ��������
        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[files.Length];
        for (int i = 0; i < files.Length; ++i)
        {
            string scenePath = files[i];
            // ͨ��scene·����ʼ��
            scenes[i] = new EditorBuildSettingsScene(scenePath, true);
        }

        // ���� scene ����
        EditorBuildSettings.scenes = scenes;
    }
}