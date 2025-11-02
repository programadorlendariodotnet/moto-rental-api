namespace Api.Controllers.Utils;

public sealed record CustomResponseDto(
    bool Success,
    int StatusCode,
    object? Data,
    List<string> Messages,
    DateTimeOffset DateTimeUtc);