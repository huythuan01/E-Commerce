namespace Client.ApplicationStates
{
    public class AllState
    {
        //Scope action
        public Action? Action { get; set; }

        //General Department
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClicked()
        {
            ResetAllDepartment();
            ShowGeneralDepartment = true;
            Action?.Invoke();
        }

        //Department
        public bool ShowDepartment { get; set; }
        public void DepartmentClicked()
        {
            ResetAllDepartment();
            ShowDepartment = true;
            Action?.Invoke();
        }

        //Branch
        public bool ShowBranch { get; set; }
        public void BranchClicked()
        {
            ResetAllDepartment();
            ShowBranch = true;
            Action?.Invoke();
        }

        //Country
        public bool ShowCountry { get; set; }
        public void CountryClicked()
        {
            ResetAllDepartment();
            ShowCountry = true;
            Action?.Invoke();
        }

        //City
        public bool ShowCity { get; set; }
        public void CityClicked()
        {
            ResetAllDepartment();
            ShowCity = true;
            Action?.Invoke();
        }

        //Town
        public bool ShowTown { get; set; }
        public void TownClicked()
        {
            ResetAllDepartment();
            ShowTown = true;
            Action?.Invoke();
        }

        //User
        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAllDepartment();
            ShowUser = true;
            Action?.Invoke();
        }

        //Employee
        public bool ShowEmployee { get; set; }
        public void EmployeeClicked()
        {
            ResetAllDepartment();
            ShowEmployee = true;
            Action?.Invoke();
        }

        private void ResetAllDepartment()
        {
            ShowGeneralDepartment = false;
            ShowDepartment = false;
            ShowBranch = false;
            ShowCountry = false;
            ShowCity = false;
            ShowTown = false;
            ShowUser = false;
            ShowEmployee = false;
        }
    }
}
