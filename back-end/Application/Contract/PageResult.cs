namespace Application.Contract
{
    public record PageResult<T>(List<T> Rows, int TotalRows)
        where T : class;
}
