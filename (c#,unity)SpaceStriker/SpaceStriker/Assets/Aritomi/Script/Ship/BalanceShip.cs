using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// バランスタイプの機体
    /// 有冨勇帆
    /// </summary>
    public class BalanceShip : Player
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.BALANCE_SHIP_HP;
            offensivePower = Status.BALANCE_SHIP_OFFENSIVE_POWER;

            base.Initialize();
        }

        /// <summary>
        /// 特殊行動
        /// </summary>
        protected override void ActSpecial()
        {
            // 何もしない
        }
    }
}
