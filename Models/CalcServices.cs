namespace WebApplication1.Models
{
    public class CalcServices
    {
        public int x { get; set; }
        public int y { get; set; }         
        public char sign { get; set; }

        public string res = "";

        public string Calculate(int x, int y, char s)
        {
            int result=0; string res="";
            if (s == '+') result = (x + y);
            else if (s == '-') result = x - y;
            else if (s == '*') result = x * y;           
            else if (s == '/' && y != 0) result = x / y;
            res = result.ToString();
            if (s == '/' && y == 0) res = "На ноль делить нельзя!";
            return res;
        }

        public string Calculate(CalcServices calc)
        {
            int result = 0; string res = "";
            if (calc.sign == '+') result = (x + y);
            else if (calc.sign == '-') result = x - y;
            else if (calc.sign == '*') result = x * y;
            else if (calc.sign == '/' && y != 0) result = x / y;
            res = result.ToString();
            if (calc.sign == '/' && y == 0) res = "На ноль делить нельзя!";
            return res;
        }
    }
}
