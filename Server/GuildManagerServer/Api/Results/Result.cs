namespace GuildManagerServer.Api.Results;

/// <summary>
/// Define a result of a Service operation. It should be later mapped to IActionResults.
/// </summary>
/// <typeparam name="T">The type of data the Service operation needs to return.</typeparam>
public class Result<T>
{
    public bool Succeed { get; private set; }
    /// <summary>
    /// The result to send.
    /// </summary>
    public ResultCode? ResultCode { get; private set; }
    /// <summary>
    /// The data to send with the result. Can be NULL if the result doesn't expect data.
    /// </summary>
    public T? Data { get; private set; }
    /// <summary>
    /// The message to send with the result. Can be Empty if the result doesn't expect a message.
    /// </summary>
    public string ErrorMessage { get; private set; } = "";

    public static Result<T> Success(ResultCode successCode)
    {
        return new Result<T>{ Succeed = true, ResultCode = successCode};
    }

    public static Result<T> Success(ResultCode successCode, T nData)
    {
        return new Result<T>{ Succeed = true, ResultCode = successCode, Data = nData};
    }

    public static Result<T> Failure(ResultCode failureCode)
    {
        return new Result<T>{ Succeed = false, ResultCode = failureCode};
    }

    public static Result<T> Failure(ResultCode failureCode, string failureMessage)
    {
        return new Result<T>{ Succeed = false, ResultCode = failureCode, ErrorMessage = failureMessage };
    }

    /// <summary>
    /// Map the data to an other type.
    /// </summary>
    /// <typeparam name="TOut">The type in which the data must be mapped.</typeparam>
    /// <param name="mapper">The method used to map the data.</param>
    /// <returns>The new result with the mapped data.</returns>
    public Result<TOut> Map<TOut>(Func<T, TOut> mapper)
    {
        if(Data == null)
        {
            return new Result<TOut>{ ResultCode = this.ResultCode, ErrorMessage = this.ErrorMessage };
        }

        return new Result<TOut>{ ResultCode = this.ResultCode, Data = mapper(this.Data) };
    }
}
