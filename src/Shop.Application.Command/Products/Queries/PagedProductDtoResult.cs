public record PagedProductDtoResult(IReadOnlyList<ProductDto> ProductDtos, int TotalCount, int Page, int PageSize);
