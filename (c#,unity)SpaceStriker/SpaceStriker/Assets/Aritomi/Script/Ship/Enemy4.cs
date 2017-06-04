using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー４
    /// 有冨勇帆
    /// </summary>
    public class Enemy4 : Enemy
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            //ステータス初期化
            hp              = Status.ENEMY_SHIP_4_HP;
            offensivePower  = Status.ENEMY_SHIP_4_OFFENSIVE_POWER;
            AILevel         = Status.ENEMY_SHIP_4_AI;

            base.Initialize();
        }
    }
}