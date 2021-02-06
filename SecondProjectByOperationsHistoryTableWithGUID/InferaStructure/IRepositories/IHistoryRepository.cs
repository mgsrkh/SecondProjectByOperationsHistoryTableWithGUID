using SecondProjectByOperationsHistoryTableWithGUID.Models;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories
{
    public interface IHistoryRepository
    {
        Task<int> InsertHistoryAndVendorAsync(Vendor vendor, History history);
    }
}
