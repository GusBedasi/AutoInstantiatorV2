using Microsoft.AspNetCore.Mvc;
using PaymentMethodAutoInstantiator;
using System.Reflection;

namespace PaymentMethodAutoInstantiator.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public PaymentsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            var assembly = typeof(IPaymentMethod).GetTypeInfo().Assembly;

            var instancedPaymentMethod = assembly.DefinedTypes
                .Where(t => t.ImplementedInterfaces.Any(x => x == typeof(IPaymentMethod)))
                .Select(x => x.UnderlyingSystemType);

            var @list = new List<IPaymentMethod>();

            foreach (var item in instancedPaymentMethod)
            {
                if (item is not null)
                    @list.Add((IPaymentMethod)ActivatorUtilities.CreateInstance(_serviceProvider, item));
            }

            var response = string.Join(", ", @list.Select(x => x.GetType().Name));

            return Ok(response);
        }
    }
}
