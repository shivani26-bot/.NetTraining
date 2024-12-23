namespace EmployeeMicroservice.Models.DTOs
{

    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
    public class EmployeeCityFilter //filter by city
    {

        public string CityName { get; set; } = "";
        public bool IsExactMatch { get; set; } = false;
    }
    public class EmployeeAgeFilter //filter by age
    {
        public int MinAge { get; set; } = 0;
        public int MaxAge { get; set; } = 0;
    }
  
    public class EmployeeRequestDTO
    {

        public EmployeeAgeFilter? AgeFilter { get; set; }
        public EmployeeCityFilter? CityFilter { get; set; }
     
        public Pagination? Pagination { get; set; }

        //Sort by name ascending 1, descending -1
        //sort by age ascending 2, descending -2

        public int? SortOrder { get; set; }
        public EmployeeRequestDTO()
        {
            AgeFilter = new  EmployeeAgeFilter();
           CityFilter = new EmployeeCityFilter();
            Pagination = new Pagination();
        }
    }
}
