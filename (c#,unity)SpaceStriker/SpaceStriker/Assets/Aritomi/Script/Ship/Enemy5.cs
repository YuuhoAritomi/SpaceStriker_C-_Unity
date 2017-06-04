using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー５
    /// 有冨勇帆
    /// </summary>
    public class Enemy5 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_5_HP;
            offensivePower  = Status.ENEMY_SHIP_5_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_5_AI;

            base.Initialize();
        }
    }
}