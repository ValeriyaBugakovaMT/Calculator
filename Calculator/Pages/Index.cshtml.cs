using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Calculator.Logic;
using Microsoft.AspNetCore.Http;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {
        private string _operator = "";
        public string _firstNumber = "";
        public string _secondNumber = "";
        private readonly ILogger<IndexModel> _logger;
        public string Result = "0";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("Operator", "");
            HttpContext.Session.SetString("FirstNumber", "");
            HttpContext.Session.SetString("SecondNumber", "");
        }
        private void GetSession()
        {
            _firstNumber = HttpContext.Session.GetString("FirstNumber");
            _secondNumber = HttpContext.Session.GetString("SecondNumber");
            _operator = HttpContext.Session.GetString("Operator");
        }

        public void OnGet()
        {
        }

        public void OnPostOperator(string Operator)
        {
            _operator = Operator;
            HttpContext.Session.SetString("Operator", Operator);
        }
        public void OnPostNumber(string Number)
        {
            if (Number == "AC") 
            { 
                AC(); 
                return; 
            }

            GetSession();
            if (String.IsNullOrEmpty(_operator))
            {
                Result = _firstNumber == "" || _firstNumber == "0" ? Number : _firstNumber + Number;
                _firstNumber += Number;
                HttpContext.Session.SetString("FirstNumber", _firstNumber);
            }
            else
            {
                Result = _secondNumber == "" || _secondNumber == "0" ? Number : _secondNumber + Number;
                _secondNumber += Number;
                HttpContext.Session.SetString("SecondNumber", _secondNumber);
            }
        }

        public void AC()
        {
            _operator = "";
            _firstNumber = "";
            _secondNumber = "";
            Result = "0";
            SetSession();
        }
        public void OnPostCalculate()
        {
            GetSession();

            Logic.Calculator calculator = new Logic.Calculator(_firstNumber, _secondNumber, _operator);
            Result = calculator.Calculate().ToString();
            _operator = "";
            _secondNumber = "";
            SetSession();

            _firstNumber = Result;
            HttpContext.Session.SetString("FirstNumber", _firstNumber);
        }
    }
}