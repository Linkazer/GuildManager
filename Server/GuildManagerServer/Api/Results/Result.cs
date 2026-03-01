namespace GuildManagerServer.Api.Results;

public class Result<T>
{
    public ResultCode? ResultCode { get; private set; }
    public T? Data { get; private set; }

    public static Result<T> Success(ResultCode successCode)
    {
        return new Result<T>{ ResultCode = successCode};
    }

    public static Result<T> Success(ResultCode successCode, T nData)
    {
        return new Result<T>{ ResultCode = successCode, Data = nData};
    }

    public static Result<T> Failure(ResultCode failureCode)
    {
        return new Result<T>{ ResultCode = failureCode};
    }

    public Result<TOut> Map<TOut>(Func<T, TOut> mapper)
    {
        if(Data == null)
        {
            return new Result<TOut>{ ResultCode = this.ResultCode };
        }

        return new Result<TOut>{ ResultCode = this.ResultCode, Data = mapper(this.Data) };
    }
}
