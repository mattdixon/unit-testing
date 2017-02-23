using Caliburn.Micro;
using FrontRangeSystems.UnitTesting.Services.Contracts;
using FrontRangeSystems.UnitTesting.Services.Models;

namespace FrontRangeSystems.UnitTesting.WindowsClient.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private decimal _deduction;
        private int _entrants;
        private decimal _entryFee;
        private decimal _first;
        private decimal? _mathResult;
        private int _payoutPlaces;
        private decimal _prizePerPerson;
        private decimal _purse;
        private decimal _second;
        private string _selectedOperator;
        private decimal _sponsorMoney;

        public ShellViewModel(IMathService mathService, IPrizeMoneyCalculationService prizeMoneyCalculationService)
        {
            MathService = mathService;
            PrizeMoneyCalculationService = prizeMoneyCalculationService;
            Operators = new BindableCollection<string>(new[] {"+", "-", "*", "/"});
        }

        public string SelectedOperator
        {
            get { return _selectedOperator; }
            set
            {
                _selectedOperator = value;
                NotifyOfPropertyChange();
                DoMathCalculation();
            }
        }

        public decimal? MathResult
        {
            get { return _mathResult; }
            set
            {
                _mathResult = value;
                NotifyOfPropertyChange();
            }
        }

        public decimal EntryFee
        {
            get { return _entryFee; }
            set
            {
                _entryFee = value;
                NotifyOfPropertyChange();
                CalculatePrizeMoney();
            }
        }

        public int Entrants
        {
            get { return _entrants; }
            set
            {
                _entrants = value;
                NotifyOfPropertyChange();
                CalculatePrizeMoney();
            }
        }

        public decimal Deduction
        {
            get { return _deduction; }
            set
            {
                _deduction = value;
                NotifyOfPropertyChange();
                CalculatePrizeMoney();
            }
        }

        public decimal SponsorMoney
        {
            get { return _sponsorMoney; }
            set
            {
                _sponsorMoney = value;
                NotifyOfPropertyChange();
                CalculatePrizeMoney();
            }
        }

        public int PayoutPlaces
        {
            get { return _payoutPlaces; }
            set
            {
                _payoutPlaces = value;
                NotifyOfPropertyChange();
                CalculatePrizeMoney();
            }
        }

        public decimal Purse
        {
            get { return _purse; }
            set
            {
                _purse = value;
                NotifyOfPropertyChange();
            }
        }

        public decimal PrizePerPerson
        {
            get { return _prizePerPerson; }
            set
            {
                _prizePerPerson = value;
                NotifyOfPropertyChange();
            }
        }

        public BindableCollection<string> Operators { get; set; }
        private IMathService MathService { get; }
        private IPrizeMoneyCalculationService PrizeMoneyCalculationService { get; }

        public decimal First
        {
            get { return _first; }
            set
            {
                _first = value;
                NotifyOfPropertyChange();
                DoMathCalculation();
            }
        }

        public decimal Second
        {
            get { return _second; }
            set
            {
                _second = value;
                NotifyOfPropertyChange();
                DoMathCalculation();
            }
        }

        private void CalculatePrizeMoney()
        {
            var model = new PayoutCalculationModel
            {
                EntryFee = EntryFee,
                Entrants = Entrants,
                SponsorMoney = SponsorMoney,
                Deduction = Deduction,
                PayoutPlaces = PayoutPlaces
            };

            Purse = PrizeMoneyCalculationService.CalculatePurse(model);
            PrizePerPerson = PrizeMoneyCalculationService.CalculatePerPersonPayout(model);
        }

        private void DoMathCalculation()
        {
            if (string.IsNullOrWhiteSpace(SelectedOperator))
            {
                MathResult = null;
                return;
            }

            switch (SelectedOperator)
            {
                case "+":
                    MathResult = MathService.Add(First, Second);
                    break;
                case "-":
                    MathResult = MathService.Subtract(First, Second);
                    break;
                case "*":
                    MathResult = MathService.Multilpy(First, Second);
                    break;
                case "/":
                    MathResult = MathService.Divide(First, Second);
                    break;
            }
        }
    }
}