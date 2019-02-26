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
            mHP -= minus_hp;
            HP.text = "HP:" + mHP.ToString();
        }

        public void TakeAttack(int minus_mp)
        {
            mMP -= minus_mp;
            MP.text = "MP:" + mMP.ToString();
        }

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}