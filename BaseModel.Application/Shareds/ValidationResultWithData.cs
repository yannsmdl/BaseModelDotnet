using FluentValidation.Results;

namespace BaseModel.Application.Shareds
{
    public class ValidationResultWithData<T>
{
    public ValidationResult ValidationResult { get; }
    public T Data { get; }

    public ValidationResultWithData(ValidationResult validationResult, T data)
    {
        ValidationResult = validationResult;
        Data = data;
    }
}
}