namespace PaymentMethodAutoInstantiator
{
    public interface IPaymentMethod
    {

    }
    public class CreditCard : IPaymentMethod
    {
        private readonly IPaymentService _service;

        public CreditCard(IPaymentService service)
        {
            _service = service;
        }
    }

    public class DebitCard : IPaymentMethod
    {
        private readonly IPaymentService _service;

        public DebitCard(IPaymentService service)
        {
            _service = service;
        }
    }

    public class Voucher : IPaymentMethod
    {
        private readonly IPaymentService _service;

        public Voucher(IPaymentService service)
        {
            _service = service;
        }
    }

    public class Pix : IPaymentMethod
    {
        private readonly IPaymentService _service;

        public Pix(IPaymentService service)
        {
            _service = service;
        }
    }
}
