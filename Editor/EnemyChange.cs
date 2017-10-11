using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyChange : ScriptableWizard {

    [MenuItem("Tools/CreateWizard")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<EnemyChange>("统一修改敌人","Change And Close","Change");
    }

    public int changeStartHealthValue = 10;
    public int changeSinkSpeedValue = 1;

     const string changeStartHealthValueKey = "EnemyChange.changeStartHealthValue";
     const string changeSinkSpeedValueKey = "EnemyChange.changeSinkSpeedValue";
    //当窗口被创建出来的时候调用的
    void OnEnable()
     {
         changeStartHealthValue = EditorPrefs.GetInt(changeStartHealthValueKey, changeStartHealthValue);
         changeSinkSpeedValue = EditorPrefs.GetInt(changeSinkSpeedValueKey, changeSinkSpeedValue);
    }
    //检测create按钮的点击
    void OnWizardCreate()
    {
        GameObject[] enemyPrefabs = Selection.gameObjects;
        EditorUtility.DisplayProgressBar("进度", "0/" + enemyPrefabs.Length + " 完成修改值", 0);
        int count = 0;
        foreach (GameObject go in enemyPrefabs)
        {
            CompleteProject.EnemyHealth hp = go.GetComponent<CompleteProject.EnemyHealth>();
            Undo.RecordObject(hp, "change health and speed");
            hp.startingHealth += changeStartHealthValue;
            hp.sinkSpeed += changeSinkSpeedValue;
            count++;
            EditorUtility.DisplayProgressBar("进度", count+"/" + enemyPrefabs.Length + " 完成修改值", (float)count/enemyPrefabs.Length);
        }
        EditorUtility.ClearProgressBar();
        ShowNotification(new GUIContent(Selection.gameObjects.Length + "个游戏物体的值被修改了"));
    }
    void OnWizardOtherButton()
    {
        OnWizardCreate();
    }
    //当前字段值修改的时候会被调用
    void OnWizardUpdate()
    {
        errorString = null;
        helpString = null;
        if (Selection.gameObjects.Length > 0)
        {
            helpString = "您当前选择了" + Selection.gameObjects.Length + "个敌人";
        }
        else
        {
            errorString = "请选择至少一个敌人";
        }

        EditorPrefs.SetInt(changeStartHealthValueKey, changeStartHealthValue);
        EditorPrefs.SetInt(changeSinkSpeedValueKey, changeSinkSpeedValue);
    }
    void OnSelectionChange()
    {
        OnWizardUpdate();
    }

}
