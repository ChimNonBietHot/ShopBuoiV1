    using ShopBuoi.Model.Models;
using ShopBuoi.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBuoi.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        public IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbException)
            {
                LogError(dbException);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbException.InnerException);
            }
            catch (Exception exception)
            {
                LogError(exception);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, exception.Message);
            }
            return response;
        }

        private void LogError(Exception exception)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = exception.Message;
                error.StackTrace = exception.StackTrace;
                _errorService.Create(error);
                _errorService.save();
            }
            catch
            {
            }
        }
    }
}