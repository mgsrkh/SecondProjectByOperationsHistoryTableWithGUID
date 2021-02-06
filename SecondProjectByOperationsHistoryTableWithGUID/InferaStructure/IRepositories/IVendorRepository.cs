using SecondProjectByOperationsHistoryTableWithGUID.Models;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories
{
    public interface IVendorRepository
    {
        Task<Vendor> GetVendorByIdAsync(string id);
        Task<int> DeleteVendorAndInsertHistoryAsync(Vendor vendor, History history);
        Task<int> UpdateVendorAndInsertHistoryAsync(Vendor vendor, History history);
        Task<int> SaveChangeAsync();
    }
}
