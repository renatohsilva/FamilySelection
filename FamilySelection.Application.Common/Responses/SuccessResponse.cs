using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilySelection.Application.Common.Responses
{
    public class SuccessResponse
    {
        public SuccessResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { message = Message });
        }
    }
}
