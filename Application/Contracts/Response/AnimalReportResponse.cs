namespace Application.Contracts.Response
{
    public record AnimalReportResponse(
        string name, 
        string tutorName, 
        string Sexo, 
        DateTime BirthDate, 
        string species, 
        string race, 
        string coat);
}
