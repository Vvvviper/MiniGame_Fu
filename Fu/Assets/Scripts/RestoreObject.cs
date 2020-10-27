using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 修复地图能力脚本
/// 使用触发器在OnTriggerEnter时修改地图为完整状态
/// 在OnTriggerExit时修改为废土状态
/// 需要挂载在player的子物体restore上
/// </summary>
public class RestoreObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tree")
        {
            TreeAnimation change = collision.gameObject.GetComponent<TreeAnimation>();
            if (change == null)
                return;
            if (this.GetComponent<BeGleaned>().index == change.relatedBoom)
            {
                change.changeComplete(); 
                GameObject.Find("BoomManager").GetComponent<BoomManager>().FinishOneInteractive(this.GetComponent<BeGleaned>().index);
            }
            else
            {
                GameObject.Find("BoomManager").GetComponent<BoomManager>().reenableBoom(this.GetComponent<BeGleaned>().index);
            }
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Vine")
        {
            VineFillOut change = collision.gameObject.GetComponent<VineFillOut>();
            if (change == null)
                return;
            if (this.GetComponent<BeGleaned>().index == change.relatedBoom)
            {
                change.changeComplete();
                GameObject.Find("BoomManager").GetComponent<BoomManager>().FinishOneInteractive(this.GetComponent<BeGleaned>().index);
            }
            else
            {
                GameObject.Find("BoomManager").GetComponent<BoomManager>().reenableBoom(this.GetComponent<BeGleaned>().index);
            }
            Destroy(this.gameObject);
            Debug.Log("Boom reenable number" + GetComponent<BeGleaned>().index);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TreeAnimation change = collision.gameObject.GetComponent<TreeAnimation>();
        if (change == null)
            return;
        change.changeDestory();
    }
}
