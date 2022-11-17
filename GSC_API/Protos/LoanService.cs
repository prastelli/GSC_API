using Grpc.Core;
using GSC_API.DataAccess;

namespace GSC_API.Protos
{
    public class LoanService:Loan.LoanBase
    {
        private readonly LoanDBContext _context;
        public LoanService(LoanDBContext context)
        {
            _context = context;
        }
        public override Task<LoanResponse> CloseLoan(LoanRequest request,
             ServerCallContext context)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var loan = _context.Loans.Find(request.Id);
            loan.Status = !loan.Status;
            _context.Loans.Update(loan);
            _context.SaveChanges();

             return Task.FromResult(new LoanResponse
            {
                Respuesta = "Loan Close Number: " + request.Id.ToString(),
            });
        }

    }
}
