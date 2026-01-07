namespace API.DTO
{
    public class CreateOrderLineRequestDto
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
