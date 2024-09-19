using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
