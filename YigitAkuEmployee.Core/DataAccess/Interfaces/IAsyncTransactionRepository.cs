using Microsoft.EntityFrameworkCore.Storage;

namespace YigitAkuEmployee.Core.DataAccess.Interfaces;

public interface IAsyncTransactionRepository
{
   
    // DB ile bağlantı kurar, Tüm işlemler başaralısı ise uygular, başarılı değilse kayıt yapmaz. Bu işlemi de CancelationToken sayesinde yapar.
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    //DB ile bağlantı koparsa tekrar bağlanmayı sağlar.
    Task<IExecutionStrategy> CreateExecutionStrategy();

}