using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HospitalCharges
{
    class VM : INotifyPropertyChanged
    {
        //Constant for the daily charge of a hospital stay
        private const decimal DAILY_CHARGE = 350.00m;

        private int quantityStays = 0;
 
        public int QuantityStays //QuantityStays property
        {
            get { return quantityStays; }
            set { quantityStays = value; propertyChanged(); }
        }

        private decimal medicationAmount = 0;

        public decimal MedicationAmount //MedicationAmount property
        {
            get { return medicationAmount; }
            set { medicationAmount = value; propertyChanged(); }
        }

        private decimal surgeryAmount = 0;

        public decimal SurgeryAmount //SurgeryAmount property
        {
            get { return surgeryAmount; }
            set { surgeryAmount = value; propertyChanged(); }
        }

        private decimal labAmount = 0;

        public decimal LabAmount //LabAmount property
        {
            get { return labAmount; }
            set { labAmount = value; propertyChanged(); }
        }

        private decimal rehabAmount = 0;

        public decimal RehabAmount //Rehab property
        {
            get { return rehabAmount; }
            set { rehabAmount = value; propertyChanged(); }
        }

        private string results = "";

        public string Results //Results property
        {
            get { return results; }
            set { results = value; propertyChanged(); }
        }

        //Method to calculate the total of the number of days in hospital and additional charges
        public void CalcTotalCharges()
        {
            //if the number of days or medication charge or surgery charge or lab charge or rehab charge is less than zero than error
            if (QuantityStays < 0 || MedicationAmount < 0 || SurgeryAmount < 0 || LabAmount < 0 || RehabAmount < 0)
            {
                Results = "Please enter a valid number!";
            }
            else
            {
                decimal dailyAmountStay = CalcStayCharges(QuantityStays, DAILY_CHARGE); //passing QuantityStays and DAILY_CHARGE to our method CalcStayCharges
                decimal totalAdditional = CalcMiscCharges(MedicationAmount, SurgeryAmount, LabAmount, RehabAmount); //Passing all four additional charges to our method CalcMiscCharges
                //Add the total from dailyAmountStay and totalAdditional
                decimal total = dailyAmountStay + totalAdditional;

                Results = $"The total hospital stay is {total:c}";
            }
        }
        //Method to calculate the total charge of the number of days spend in the hospital
        public decimal CalcStayCharges(int quantity, decimal price)
        {
            return quantity * price;
        }

        //Method to calculate the total charges of the additional items
        public decimal CalcMiscCharges(decimal medication, decimal surgery, decimal lab, decimal rehab)
        {
            decimal totalMisc = 0;
            totalMisc = medication + surgery + lab + rehab;
            return totalMisc;
        }

        //Clear method to clear the results, and the textboxes
        public void Clear()
        {
            Results = "";
            MedicationAmount = 0;
            SurgeryAmount = 0;
            LabAmount = 0;
            RehabAmount = 0;
            QuantityStays = 0;
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
