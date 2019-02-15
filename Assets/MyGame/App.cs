using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MyGame
{
    public class App : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            ResMgr.Init();
            UIMgr.SetResolution(1024, 768, 0);

            UIMgr.OpenPanel<UIUsrCardsArea>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
