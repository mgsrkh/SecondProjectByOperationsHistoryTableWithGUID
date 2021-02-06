using Microsoft.EntityFrameworkCore;
using SecondProjectByOperationsHistoryTableWithGUID.Contexts;
using SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories;
using SecondProjectByOperationsHistoryTableWithGUID.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ProjectContext _db;

        public VendorRepository(ProjectContext db)
        {
            _db = db;
        }
        public async Task<Vendor> GetVendorByIdAsync(string id)
        {
            return await _db.Vendor.Where(v => v.Id == id).Include(t => t.Tags).SingleOrDefaultAsync();
        }

        public async Task<int> DeleteVendorAndInsertHistoryAsync(Vendor vendor, History history)
        {
            _db.History.Add(history);
            _db.Vendor.Remove(vendor);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> UpdateVendorAndInsertHistoryAsync(Vendor vendor, History history)
        {
            _db.History.Add(history);
            _db.Vendor.Update(vendor);
            return await _db.SaveChangesAsync();
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
