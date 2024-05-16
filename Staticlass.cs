
using System;
using System.Collections.Generic;
using UnityEngine;
namespace TeenPatti
{

    public static class Staticlass
    {
        public static readonly string Blind = "Blind";
        public static readonly string Chall = "Chal";
        public static readonly string Seen = "Seen";
        public static readonly string Pack = "Pack";

        /// <summary>
        /// conver to specific enum
        /// </summary>
        /// <typeparam name="CardType"></typeparam>
        /// <param name="strEnumValue"></param>
        /// <returns></returns>
        public static CardType StringToEnum<CardType>(this string strEnumValue)
        {
            return (CardType)Enum.Parse(typeof(CardType), strEnumValue);
        }


        /// <summary>
        /// get sort amount in k,L,Cr,etc
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static string GetString(this float amount)
        {
            if (amount > 10000000)
                return (amount / 10000000).ToString(".00") + "Cr";

            if (amount > 100000)
                return (amount / 100000).ToString(".00") + "L";

            if (amount > 1000)
                return (amount / 1000).ToString(".00") + "K";

            return amount.ToString();
        }


        /// <summary>
        /// Hide the gameobject in hirarchy
        /// </summary>
        /// <param name="ob"></param>
        public static void Hide(this GameObject ob) => ob.SetActive(false);
        /// <summary>
        /// Hide commponant gameobject in hirarchy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Hide<T>(this T obj) where T : Component
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Trying to hide a null object." + obj);
            }
        }

        /// <summary>
        ///  Show the gameobject in hirarchy
        /// </summary>
        /// <param name="ob"></param>
        public static void Show(this GameObject ob) => ob.SetActive(true);
        /// <summary>
        ///  Hide componant the gameobject in hirarchy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Show<T>(this T obj) where T : Component
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Trying to hide a null object.");
            }
        }

        /// <summary>
        /// Convert Enum to string
        /// </summary>
        /// <param name="eff"></param>
        /// <returns></returns>
        public static String EnumToString(this Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

        private static System.Random rng = new System.Random();


        /// <summary>
        /// Suffle the list element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }

    [System.Serializable]
    public class CardDetail
    {
        public int CardId;
        public CardType CardName;
        public Sprite CardSprite;
        public CardDetail() { }
        public CardDetail(int id, string name, Sprite sprite)
        {
            CardId = id;
            CardName = name.StringToEnum<CardType>();
            CardSprite = sprite;
        }

        public CardDetail GetCardDetail() => this;
    }


    [System.Serializable]
    public class CardSet
    {
        public string playerID;
        public Catagory catagory;
        public int HighCard;
        public int MiddleCard;
        public int LowCard;
        public void SetCard(string id, int high, int middle, int low, Catagory cat)
        {
            playerID = id;
            HighCard = high;
            MiddleCard = middle;
            LowCard = low;
            this.catagory = cat;
        }
        public CardSet GetCardSet() => this;
    }


    public enum playerStatus
    {
        Waiting,
        played,
        packed
    }
    public enum cardstatus
    {
        Waiting,
        Blind,
        Seen,
        Packed
    }

    public enum CardType
    {
        Club = 0,
        Daimond = 1,
        Heart = 2,
        Spade = 3,
    }

    public enum Catagory
    {
        High_Card = 0,
        Double = 1,
        Colour = 2,
        Sequence = 3,
        Pure_sequence = 4,
        Trio = 5,
    }
    public enum SocketEvent
    {
        SIGN_UP,
        HEART_BEAT,
        DISCARD_CARD,
        END_DRAG,
        PICK_CARD_FROM_OPEN_DECK,
        PICK_CARD_FROM_CLOSE_DECK,
        CARDS_IN_SORTS,
        REJOIN_I_AM_BACK,
        SHOW_OPENDECK_CARDS,
        FINISH_TIMER_STARTED,
        DECLARE,
        LEAVE_TABLE,
        LAST_DEAL,
        SETTING_MENU_GAME_TABLE_INFO,
        REJOIN_OR_NEW_GAME,
        JOIN_TABLE,
        GAME_START_COUNT_DOWN,
        COLLECT_BOOT_VALUE,
        SET_DEALER,
        PROVIDED_CARDS,
        USER_TURN_STARTED,
        WINNER,
        SCORE_BORAD,
        TOSS_CARD,
        RESUFFAL_CARD,
        POPUP,
        LOCK_IN_PERIOD,
        UPDATE_USER_WALLET,
        REJOIN_POPUP,
        SHOW_POP,
        WAITING_FOR_PLAYER,
        ROUND_TIMER_STARTED,
        GROUP_CARDS,
        DROP_ROUND,
        SCOREBOARD_TIMER_AND_SPLIT,
        DECLARE_IN_SCORE_BOARD,
        MANUAL_SPLIT_AMOUNT,
        SPLIT_AMOUNT,
        REJOIN_TABLE,
        SCORE_CARD,
        NEW_GAME_START,
        SWITCH_TABLE,
        ARRANGE_SEATING,
        REJOIN_GAME_AGAIN
    }
    public enum PlayingStatus
    {
        WRONG_DECLARED,
        LEFT,
        LOST,
        WINNER_DECLARED,
        DECLARED,
        SPLIT_AMOUNT,
        WIN_ROUND,
        DECLARING,
        DROP_TABLE_ROUND,
        ELIMINATED,
        WIN,
        DRAW,
    }
    public enum RequestEvent
    {
        MANUAL_SPLIT_AMOUNT,
        SPLIT_AMOUNT,
    }
    public enum ServerPopupType
    {
        centerToastPopup,
        commonPopup,
        topToastPopup,
        middleToastPopup,
        commonToastPopup,
        topMiddleTostPopup,
        downCenterToastPopup,
        waitMiddleToastPopup,
        none,
    }
    public enum TeenpattiTableState
    {
        None,
        WAIT_FOR_PLAYER,
        WAITING_FOR_PLAYERS,
        ROUND_TIMER_STARTED,
        LOCK_IN_PERIOD,
        COLLECTING_BOOT_VALUE,
        PROVIDED_CARDS,
        TURN_STARTED,
        ROUND_STARTED,
        FINISH_TIMER_START,
        ROUND_OVER,
        DISPLAY_SCOREBOARD,
        AUTO_SPLIT_AMOUNT_START,
        CARD_DEALING,
        TOSS_CARDS,
    }
    public enum CardPlayingState
    {
        CARD_DEALING,
        DECLAREING,
        DECLARED,
    }
    public enum OfflinePopup
    {
        CenterToast,
        LockInPeriod,
        BottamToast,
        CommonToastPopup,
    }

}