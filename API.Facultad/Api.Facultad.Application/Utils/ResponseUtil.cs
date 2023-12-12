using Api.Facultad.Domain.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Facultad.Application.Utils
{
    public static class ResponseUtil
    {
        public static ResponseBase OK(object payload, string? message = null)
        {
            return new ResponseBase(200, message, payload);
        }

        public static ResponseBase Created(object payload, string? message = null)
        {
            return new ResponseBase(201, message, payload);
        }

        public static ResponseBase NoContent(string? message = null)
        {
            return new ResponseBase(204, message);
        }

        public static ResponseBase BadRequest(string message)
        {
            return new ResponseBase(400, message);
        }

        public static ResponseBase BadRequest(string[] errors, string? message = null)
        {
            return new ResponseBase(400, message, errors);
        }

        public static ResponseBase NotFoundRequest(string message)
        {
            return new ResponseBase(404, message);
        }

        public static ResponseBase InternalError(string? message = null)
        {
            return new ResponseBase(500, message);
        }

        public static ResponseBase Conflict(object payload, string? message = null)
        {
            return new ResponseBase(409, message, payload);
        }

        public static ResponseBase CustomResponse(HttpStatusCode statusCode, object payload, string? message)
        {
            return new ResponseBase
            {
                Code = (int)statusCode,
                Message = message,
                Payload = payload
            };
        }
    }
}
