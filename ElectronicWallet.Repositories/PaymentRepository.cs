using ElectronicWallet.Database;
using ElectronicWallet.Entities;
using ElectronicWallet.Repositories.Contracts;

namespace ElectronicWallet.Repositories
{
    public class PaymentRepository: RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(ElectronicWalletContext context): base (context)
        {

        }
    }
}
