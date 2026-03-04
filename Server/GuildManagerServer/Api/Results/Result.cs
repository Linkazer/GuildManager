namespace GuildManagerServer.Api.Results;

public class Result
{
    public bool Succeed { get; protected set; }
    /// <summary>
    /// The result to send.
    /// </summary>
    public ResultCode? ResultCode { get; protected set; }
    /// <summary>
    /// The message to send with the result. Can be Empty if the result doesn't expect a message.
    /// </summary>
    public KeyValuePair<string, string[]> ErrorMessage { get; protected set; }

    protected static Result Create(bool nSucceed, ResultCode? nResultCode, KeyValuePair<string, string[]>? nErrorMessage = null)
    {
        return new Result
        {
            Succeed = nSucceed,
            ResultCode = nResultCode,
            ErrorMessage = nErrorMessage ?? default
        };
    }

    public static Result Success(ResultCode successCode)
    {
        return Create(true, successCode);
    }

    public static Result Failure(ResultCode failureCode)
    {
        return Create(false, failureCode);
    }

    public static Result Failure(ResultCode failureCode, KeyValuePair<string, string[]> failureMessage)
    {
        return Create(false, failureCode, failureMessage);
    }
}

/// <summary>
/// Define a result of a Service operation. It should be later mapped to IActionResults.
/// </summary>
/// <typeparam name="T">The type of data the Service operation needs to return.</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// The data to send with the result. Can be NULL if the result doesn't expect data.
    /// </summary>
    public T? Data { get; private set; }

    protected static Result<T> CreateAsT(bool nSucceed, ResultCode? nResultCode, KeyValuePair<string, string[]>? nErrorMessage = null)
    {
        return new Result<T>
        {
            Succeed = nSucceed,
            ResultCode = nResultCode,
            ErrorMessage = nErrorMessage ?? default
        };
    }

    public static Result<T> Success(ResultCode successCode, T nData)
    {
        Result<T> result = CreateAsT(true, successCode);
        result.Data = nData;
        return result;
    }

    public static new Result<T> Failure(ResultCode failureCode)
    {
        return CreateAsT(false, failureCode);
    }

    public static new Result<T> Failure(ResultCode failureCode, KeyValuePair<string, string[]> failureMessage)
    {
        return CreateAsT(false, failureCode, failureMessage);
    }

    public static Result<T> FromResult(Result nResult)
    {
        return CreateAsT(nResult.Succeed, nResult.ResultCode, nResult.ErrorMessage);
    }

    /// <summary>
    /// Map the data to an other type.
    /// </summary>
    /// <typeparam name="TOut">The type in which the data must be mapped.</typeparam>
    /// <param name="mapper">The method used to map the data.</param>
    /// <returns>The new result with the mapped data.</returns>
    public Result<TOut> MapData<TOut>(Func<T, TOut> mapper)
    {
        if(Data == null)
        {
            return new Result<TOut>{ Succeed = this.Succeed, ResultCode = this.ResultCode, ErrorMessage = this.ErrorMessage };
        }

        return new Result<TOut>{ Succeed = this.Succeed, ResultCode = this.ResultCode, Data = mapper(this.Data) };
    }
}
