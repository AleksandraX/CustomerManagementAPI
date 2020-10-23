using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CustomerManagementPortal.Api.Formatters
{
    public class CsvCustomFormatter : TextOutputFormatter
    {
        public CsvCustomFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(CompanyDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<CompanyDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }
    }
}
