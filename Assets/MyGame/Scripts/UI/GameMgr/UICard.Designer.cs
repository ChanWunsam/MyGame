/****************************************************************************
 * 2019.2 sysu_wuzh’s Mac mini
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MyGame
{
	public partial class UICard
	{
		[SerializeField] public Text MP_need;
		[SerializeField] public Text HP_damage;
		[SerializeField] public Button AreaClick;

		public void Clear()
		{
			MP_need = null;
			HP_damage = null;
			AreaClick = null;
		}

		public override string ComponentName
		{
			get { return "UICard";}
		}
	}
}
