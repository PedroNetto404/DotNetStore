using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStore.Api.Models.Requests;

public record GetOrdersRequest : PagedRequest
{
    [Required]
    [DefaultValue("customer_id")]
    [AllowedValues("customer_id", "id")]
    public string SortBy { get; init; } = string.Empty;

    [Required]
    [DefaultValue("asc")]
    [AllowedValues("asc", "desc")]
    public string SortOrder { get; init; } = string.Empty;
}

public record PagedRequest
{
    [FromQuery(Name = "page_index")]
    [Range(1, int.MaxValue)]
    [DefaultValue(1)]
    public int PageIndex { get; set; }

    [FromQuery(Name = "page_size")]
    [Range(1, 100)]
    [DefaultValue(10)]
    public int PageSize { get; set; }
}
