using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// ディフェンスタイプの機体
    /// </summary>
    public class DefenseShip : Player
    {
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            // ステータス初期化
            hp = Status.DEFENSE_SHIP_HP;
            offensivePower = Status.DEFENSE_SHIP_OFFENSIVE_POWER;

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