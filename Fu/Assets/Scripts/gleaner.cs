using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 拾取物体的脚本
/// 说明：
/// 挂载在player物体上,当与道具的collider碰撞时会出发道具拾取操作
/// 道具的碰撞体设为collider
/// </summary>
public class gleaner : MonoBehaviour
{
    [Header("道具")]
    public GameObject[] objects;     //道具
    /// <summary>
    /// 道具数量数组应与道具数组严格对齐
    /// </summary>
    public int[] objectNumber;      //道具数量    
    // Start is called before the first frame update
    void Start()
    {
        objectNumber = new int[objects.Length];
    }
  
    /// <summary>
    /// 更新道具栏
    /// UI界面未知
    /// 暂时只写了更新道具数量的部分
    /// </summary>
    void updateUI()
    {

    }
    /// <summary>
    /// 拾取道具
    /// </summary>
    /// <param name="index">
    /// 道具的索引
    /// </param>
    public void gleanObject(int index)
    {
        objectNumber[index]++;
    }
    /// <summary>
    /// 使用道具
    /// </summary>
    /// <param name="index">
    /// 使用的道具的索引
    /// </param>
    public void useObject(int index)
    {
        if (objectNumber[index] == 0)
            return;
        objectNumber[index]--;
        //道具使用过后的行为暂时空缺
        //用发出一个直线飞行的炸弹作为demo
        GameObject boom = Instantiate(objects[index], transform.position, Quaternion.identity) as GameObject;


        Debug.Log("Player use object");
        if (boom.GetComponent<BoomMove>() != null)
        {
            boom.GetComponent<BoomMove>().face = GetComponent<PlayerMove>().face;
        }
    }
}
