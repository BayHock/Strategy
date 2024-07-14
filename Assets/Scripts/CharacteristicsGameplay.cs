using UnityEngine;

public class CharacteristicsGameplay : MonoBehaviour
{
    public class IconsGame
    {
        public int Money { get; set; }
        public int Food { get; set; }
        public int Army { get; set; }
        public int Happiness { get; set; }
        public int Religion { get; set; }
        public int Order { get; set; }

        public IconsGame() { }
        public IconsGame(int money, int food, int army, int happiness, int religion, int order)
        {
            this.Money = money;
            this.Food = food;
            this.Army = army;
            this.Happiness = happiness;
            this.Religion = religion;
            this.Order = order;
        }
    }

}
