namespace BigCorp.EmployeeApi.RequestModels
{
    public class AddEmployeeRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class AddSalariedEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Salary { get; set; }
    }

    public class AddHourlyEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Rate { get; set; }
    }

    public class AddCommissionedEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Salary { get; set; }
        public decimal Rate { get; set; }
    }
}