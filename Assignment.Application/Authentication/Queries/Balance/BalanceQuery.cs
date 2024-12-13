namespace Assignment.Application.Authentication.Queries.Balance;

public record BalanceQuery(Guid UserId) : IRequest<BalanceResponse>; //Balance Query Param
