namespace API.DTO
{
    public class CreateOrderRequestDto
    {
        public List<CreateOrderLineRequestDto>? Lines { get; init; }
    }
}
