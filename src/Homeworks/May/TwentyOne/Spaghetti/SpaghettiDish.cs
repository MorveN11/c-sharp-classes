namespace UglyCode
{
    public class SpaghettiDish
    {
        private const byte dishQuantity = 10;

        public Spaghetti Noodle { get; set; }

        public event EventHandler? UseIndexerEvent;

        public bool isReady;

        public SpaghettiDish(Spaghetti noodle)
        {
            Noodle = noodle;
            isReady = true;
        }

        public char this[int index]
        {
            get
            {
                UseIndexerEvent?.Invoke(this, EventArgs.Empty);

                return Noodle.GetNoodleName()[index];
            }
        }

        public byte GetDishQuantity()
        {
            return dishQuantity;
        }

        public string Mix(string noodle)
        {
            string ans = "";
            int length = noodle.Length;

            for (int i = 0; i < length; i++)
            {
                ans += noodle[length - 1 - i];
            }

            return ans;
        }

        public static string operator +(SpaghettiDish dish, byte count)
        {
            string ans = dish.Noodle.GetNoodleName();
            char lastChar = ans[^1];

            return ans + new string(lastChar, count);
        }

        public static string operator -(SpaghettiDish dish, byte count)
        {
            string ans = dish.Noodle.GetNoodleName();

            return ans.Substring(0, ans.Length - count - 1);
        }

        public static string operator +(byte count, SpaghettiDish dish)
        {
            string ans = dish.Noodle.GetNoodleName();
            char firstChar = ans[0];

            return new string(firstChar, count) + ans;
        }

        public class Spaghetti
        {
            private readonly char[] noodleName = { 's', 'p', 'a', 'g', 'h', 'e', 't', 't', 'i' };
            private byte noodleQuantity;

            public Spaghetti(byte noodleQuantity)
            {
                this.noodleQuantity = noodleQuantity;
            }

            public string GetNoodleName()
            {
                return new string(noodleName);
            }

            public byte GetNoodleQuantity()
            {
                return noodleQuantity;
            }
        }
    }
}
