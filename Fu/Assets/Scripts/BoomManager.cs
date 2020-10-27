using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomManager : MonoBehaviour
{
    public GameObject gleanBoom1;
    public GameObject gleanBoom2;
    public GameObject gleanBoom3;
    public List<BoomInformation> BoomInfor;
    void Start()
    {
        BoomInfor = new List<BoomInformation>()
        {
            new BoomInformation{ finished =  false, twointeractive =  false },
             new BoomInformation{ finished =  false, twointeractive =  true },
              new BoomInformation{ finished =  false, twointeractive =  false },

        };
    }
    public void reenableBoom(int index)
    {
        if (!BoomInfor[index].finished)
        {
            switch (index)
            {
                case 0:
                    gleanBoom1.SetActive(true);
                    break;
                case 1:
                    gleanBoom2.SetActive(true);
                    break;
                case 2:
                    gleanBoom3.SetActive(true);
                    break;
                default:
                    break;

            }
        }
    }
    public void Finish(int index)
    {
        BoomInfor[index].finished = true;
        reenableBoom(index);
    }
    public void FinishOneInteractive(int index)
    {
        if (BoomInfor[index].twointeractive)
        {
            BoomInfor[index].twointeractive = false;
            reenableBoom(index);
        }
        else
        {
            Finish(index);
        }
    }
    public class BoomInformation{
        public bool finished;
        public  bool twointeractive;
    }

}
