namespace Calculator.Logic
{
    public class Calculator
    {
        private decimal _FirstNumber { get; set; } = 0;
        private decimal _SecondNumber { get; set; } = 0;
        private string _Operator { get; set; }
        public Calculator(string FirstNumber, string SecondNumber, string Operator)
        {
            Decimal.TryParse(FirstNumber, out decimal result);
            _FirstNumber = result;

            Decimal.TryParse(SecondNumber, out result);
            _SecondNumber = result;

            _Operator = Operator;
        }

        private decimal DoOperation()
        {
            switch (_Operator)
            {
                case "Plus": return _FirstNumber + _SecondNumber;
                case "Minus": return _FirstNumber - _SecondNumber;
                case "Divide": return _FirstNumber / _SecondNumber;
                case "Multiply": return _FirstNumber * _SecondNumber;
                default: return _FirstNumber;
            }
        }

        public decimal Calculate() 
        {
            return DoOperation();
        }
    }
}
