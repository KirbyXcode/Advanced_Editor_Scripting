using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerEditor  {
    [MenuItem("CONTEXT/PlayerHealth/InitHealthAndSpeed")]// CONTEXT 组件名 按钮名
    static void InitHealthAndSpeed( MenuCommand cmd )//menucommand是当前正在操作的组件
    {
        //Debug.Log(cmd.context.GetType().FullName);
        CompleteProject.PlayerHealth health = cmd.context as CompleteProject.PlayerHealth;
        health.startingHealth = 200;
        health.flashSpeed = 10;
        Debug.Log("Init");
    }
    [MenuItem("CONTEXT/Rigidbody/Clear")]
    static void ClearMassAndGravity( MenuCommand cmd )
    {
        Rigidbody rgd = cmd.context as Rigidbody;
        rgd.mass = 0;
        rgd.useGravity = false;
    }
}
