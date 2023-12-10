using Shared.Exceptions.Types;

namespace Shared.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) => exception switch
    {
        BusinessExceptions businessExceptions => HandleException(businessExceptions),
        //ValidationExceptions validationExceptions => HandleException(validationExceptions),
        _ => HandleException(exception)
    };
    
    protected abstract Task HandleException(BusinessExceptions businessExceptions);
    //protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(Exception exception);
}