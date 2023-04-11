namespace Application.Contracts.Response
{
    
    // utilizado para visualizar quando o usuário digitar o código do produto na entrada de produto
    public record ProductEntryResponse(
        Guid Id, 
        string Code, string Name, 
        string CategoryName, string BrandName, decimal CostValue);
    
}
