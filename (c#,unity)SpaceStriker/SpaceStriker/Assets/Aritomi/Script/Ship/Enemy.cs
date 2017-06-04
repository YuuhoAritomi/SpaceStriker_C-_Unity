using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// エネミー
    /// 有冨勇帆
    /// </summary>
    public class Enemy : SpaceShip
    {
        [SerializeField]
        Sensor sensor;      //! AI制御用コリダー

        protected int AILevel;  //! 確率操作

        /// <summary>
        /// ステップ
        /// </summary>
        private enum Step
        {
            ACTION_WAIT,        //! 待機状態
            ACTION_AVOIDANCE,   //! 回避状態
            ACTION_SHOT         //! 攻撃状態
        }

        private Step step;  //! ステップ

        /// <summary>
        /// ショットタイプ
        /// </summary>
        private InputState[] shotType = new InputState[]
        {
            InputState.TOUCH_TOP,       //! 通常弾
            InputState.TOUCH_RIGHT,     //! 右カーブ弾
            InputState.TOUCH_LEFT       //! 左カーブ弾
        };

        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            // 場面を初期化
            step = Step.ACTION_WAIT;

            base.Initialize();
        }

        /// <summary>
        /// 特殊行動
        /// </summary>
        protected override void ActSpecial()
        {

        }

        private bool flag_chage;    //! 次の攻撃が可能か？

        /// <summary>
        /// 更新
        /// </summary>
        protected override void ShipUpdate()
        {
            if (!(bCanAct)) 
            {
                DebugLog("エネミーは行動しているので何もできない。");
                return;
            }

            switch (step)
            {  
                case Step.ACTION_WAIT:      // 待機
                    Wait();
                    return;
                case Step.ACTION_AVOIDANCE: // 回避
                    Avoidance();
                    return;
                case Step.ACTION_SHOT:      // 攻撃
                    Shot();
                    return;
            }
        }

        /// <summary>
        /// 待機
        /// </summary>
        private void Wait()
        {
            if (Random.Range(0, AILevel) == 0)
            {
                step = Step.ACTION_SHOT;
                return;
            }

            if (sensor.GetFlagCol())
            {
                step = Step.ACTION_AVOIDANCE;
                return;
            }
            DebugLog("エネミーは様子を見ている。");
        }

        /// <summary>
        /// 回避
        /// </summary>
        private void Avoidance()
        {
            DebugLog("エネミーは弾を検知した。");
            if (sensor.ColNormalBullet())
            {
                ssInputState = InputState.TOUCH_BOTTOM;
            }
            if (sensor.ColRightBullet())
            {
                ssInputState = InputState.FLICK_RIGHT;
            }
            if (sensor.ColLeftBullet())
            {
                ssInputState = InputState.FLICK_LEFT;
            }

            sensor.ColInitialize();
            step = Step.ACTION_WAIT;
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        private void Shot()
        {
            int select_bullet = 0;

            DebugLog("エネミーは弾を撃つことにした。");

            if (!flag_chage)
            {
                select_bullet = Random.Range(0, 3);
            }

            ssInputState = shotType[select_bullet];

            if (select_bullet == 3)
            {
                flag_chage = true;
                ssInputState = InputState.TOUCH_TRUE;
                if (bCanChageShot == true)
                {
                    ssInputState = InputState.TOUCH_TOP;
                    flag_chage = false;
                }
            }

            sensor.ColInitialize();
            step = Step.ACTION_WAIT;
        }
    }
}