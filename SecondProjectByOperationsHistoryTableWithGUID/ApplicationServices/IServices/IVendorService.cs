using SecondProjectByOperationsHistoryTableWithGUID.DTOs.Vendors;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.IServices
{
    public interface IVendorService
    {
        Task<VendorDTO> GetVendorByIdAsync(string id);
        Task<bool> DeleteVendorByIdAsync(string id);
        Task<int> UpdateVendorAsync(VendorUpdateDTO DTO, string Id);
        Task<VendorInsertResponseDTO> InsertVendorAsync(VendorInsertDTO dto);
    }
}
