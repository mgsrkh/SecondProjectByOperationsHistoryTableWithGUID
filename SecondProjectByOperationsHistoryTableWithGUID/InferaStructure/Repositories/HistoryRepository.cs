using SecondProjectByOperationsHistoryTableWithGUID.Contexts;
using SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories;
using SecondProjectByOperationsHistoryTableWithGUID.Models;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ProjectContext _db;

        public HistoryRepository(ProjectContext db)
        {
            _db = db;
        }

        public async Task<int> InsertHistoryAndVendorAsync(Vendor vendor, History history)
        {
            _db.Vendor.Add(vendor);
            _db.History.Add(history);
            return await _db.SaveChangesAsync();
        }
    }
}
