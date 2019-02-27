/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UIUsrMsg : UIElement
	{
        int mHP;
        int mMP;

        public void Init(int hp, int mp)
        {
            mHP = hp;
            mMP = mp;
            HP.text = "HP:" + mHP.ToString();
            MP.text = "MP:" + mMP.ToString();
        }

        public void GetDamage(int minus_hp)
        {
            if (minus_hp > mHP)
            {
                Log.W("Usr has dead!");
                Application.Quit();
                return;
            }
            mHP -= minus_hp;
            HP.text = "HP:" + mHP.ToString();
        }

        public bool TakeAttack(int minus_mp)
        {
            if (minus_mp > mMP)
            {
                Log.I("Usr's attack Invalid");
                return false;
            }
            mMP -= minus_mp;
            MP.text = "MP:" + mMP.ToString();
            return true;
        }

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}