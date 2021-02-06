using Newtonsoft.Json;
using SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.IServices;
using SecondProjectByOperationsHistoryTableWithGUID.DTOs.Tags;
using SecondProjectByOperationsHistoryTableWithGUID.DTOs.Vendors;
using SecondProjectByOperationsHistoryTableWithGUID.InferaStructure.IRepositories;
using SecondProjectByOperationsHistoryTableWithGUID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repository;
        private readonly IHistoryRepository _historyRepository;

        public VendorService(IVendorRepository repository, IHistoryRepository historyRepository)
        {
            _repository = repository;
            _historyRepository = historyRepository;
        }

        public async Task<VendorDTO> GetVendorByIdAsync(string id)
        {
            var data = await _repository.GetVendorByIdAsync(id);

            var listDTO = data.Tags.Select(x => new TagDTO
            {
                Name = x.Name,
                Value = x.Value
            }).ToList();

            VendorDTO vendorDTO = new VendorDTO
            {
                Name = data.Name,
                Title = data.Title,
                Date = data.Date,
                Tags = listDTO
            };

            return vendorDTO;
        }
        public async Task<bool> DeleteVendorByIdAsync(string id)
        {
            bool deleted = false;


            var getVendorForDelete = await _repository.GetVendorByIdAsync(id);


            var vendorDeleteDTO = new VendorUpdateDTO
            {
                Id = getVendorForDelete.Id,
                Name = getVendorForDelete.Name,
                Title = getVendorForDelete.Title,
                Date = getVendorForDelete.Date
            };
            string json = JsonConvert.SerializeObject(vendorDeleteDTO);

            var history = new History()
            {
                VendorId = vendorDeleteDTO.Id,
                Operation = "Delete",
                JsonResult = json,
            };

            await _repository.DeleteVendorAndInsertHistoryAsync(getVendorForDelete, history);

            if (getVendorForDelete != null)
            {
                deleted = true;
            }

            return deleted;
        }
        public async Task<int> UpdateVendorAsync(VendorUpdateDTO DTO, string Id)
        {
            var list = new List<Tag>();
            foreach (var item in DTO.Tags)
            {
                Tag tag = new Tag
                {
                    Name = item.Name,
                    Value = item.Value
                };
                list.Add(tag);
            }

            var ven = await _repository.GetVendorByIdAsync(Id);
            ven.Name = DTO.Name;
            ven.Title = DTO.Title;
            ven.Date = DTO.Date;
            ven.Tags = list;

            var vendorUpdateDTO = new VendorUpdateDTO
            {
                Id = ven.Id,
                Name = ven.Name,
                Title = ven.Title,
                Date = ven.Date,
                Tags = ven.Tags.Select(x => new TagDTO
                {
                    Name = x.Name,
                    Value = x.Value

                }).ToList()
            };

            string json = JsonConvert.SerializeObject(vendorUpdateDTO);

            var history = new History()
            {
                VendorId = vendorUpdateDTO.Id,
                Operation = "Put",
                JsonResult = json,
            };

            var updateVendor = await _repository.UpdateVendorAndInsertHistoryAsync(ven, history);

            return updateVendor;
        }
        public async Task<VendorInsertResponseDTO> InsertVendorAsync(VendorInsertDTO dto)
        {
            var tagList = new List<Tag>();
            if (dto.Tags != null && dto.Tags.Count > 0)
            {
                foreach (var Tag in dto.Tags)
                {
                    var tag = new Tag()
                    {
                        Name = Tag.Name,
                        Value = Tag.Value
                    };
                    tagList.Add(tag);
                }
            }
            string VendorId = Guid.NewGuid().ToString();

            var vendor = new Vendor()
            {
                Id = VendorId,
                Name = dto.Name,
                Title = dto.Title,
                Date = dto.Date,
                Tags = tagList
            };


            VendorInsertResponseDTO vendorDTO = new VendorInsertResponseDTO()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Title = vendor.Title,
                Date = vendor.Date,
                Tags = vendor.Tags.Select(x => new TagDTO
                {
                    Name = x.Name,
                    Value = x.Value

                }).ToList()
            };

            string json = JsonConvert.SerializeObject(vendorDTO);

            var history = new History()
            {
                VendorId = vendorDTO.Id,
                Operation = "Post",
                JsonResult = json,
            };

            await _historyRepository.InsertHistoryAndVendorAsync(vendor, history);

            return vendorDTO;
        }
    }
}
