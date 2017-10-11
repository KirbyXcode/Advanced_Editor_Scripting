using UnityEditor;
using UnityEngine;

public class Tools  {

    //[MenuItem("Tools/test/test1")]
    //static void Test()
    //{
    //    Debug.Log("Test");
    //}
    //[MenuItem("Tools/test/test2")]
    //static void Test2()
    //{
    //    Debug.Log("Test");
    //}
    //[MenuItem("Window/mytool/test1")]
    //static void Test3()
    //{
    //    Debug.Log("Test");
    //}
    [MenuItem("GameObject/my tool", false, 10)]
    static void Test4()
    {
        Debug.Log("Test");
    }
    [MenuItem("GameObject/my delete", true, 11)]
    static bool MyDeleteValidate()
    {
        if (Selection.objects.Length > 0)
            return true;
        else
            return false;
    }

    [MenuItem("GameObject/my delete", false, 11)]
    static void Mydelete()
    {
        foreach (Object o in Selection.objects)
        {
            //GameObject.DestroyImmediate(o);
            Undo.DestroyObjectImmediate(o);//利用Undo进行的删除操作 是可以撤销的
        }
        //需要把删除操作注册到 操作记录里面
    }
    [MenuItem("Assets/assetbutton")]
    static void Test5()
    {
        Debug.Log("Test");
    }
    
    //每一个菜单栏的priority优先级默认为1000
    [MenuItem("Tools/show info",false,1)]
    static void Test1()
    {
        //Debug.Log(Selection.activeGameObject.name );//是我们第一个选择的游戏物体 
        //Debug.Log(Selection.objects.Length);
        
    }
    //%=ctrl #=shift &=alt
    [MenuItem("Tools/test2 %q",false,100)]
    static void Test2()
    {
        Debug.Log("Test2");
    }
    [MenuItem("Tools/test3 %t",false,0)]
    static void Test3()
    {
        Debug.Log("Test3");
    }

}
