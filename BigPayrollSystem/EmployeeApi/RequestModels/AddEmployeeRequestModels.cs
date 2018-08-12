namespace BigCorp.EmployeeApi.RequestModels
{
    public abstract class AddEmployeeRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public sealed class AddSalariedEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Salary { get; set; }
    }

    public sealed class AddHourlyEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Rate { get; set; }
    }

    public sealed class AddCommissionedEmployeeRequestModel : AddEmployeeRequestModel
    {
        public decimal Salary { get; set; }
        public decimal Rate { get; set; }
    }
}