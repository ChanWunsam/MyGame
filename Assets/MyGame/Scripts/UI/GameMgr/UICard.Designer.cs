/****************************************************************************
 * 2019.2 DESKTOP-UFLMNH7
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
		[SerializeField] public Image UICardShow;

		public void Clear()
		{
			MP_need = null;
			HP_damage = null;
			AreaClick = null;
			UICardShow = null;
		}

		public override string ComponentName
		{
			get { return "UICard";}
		}
	}
}
